using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;
using Pihalve.PlaylistConverter.Application.Exceptions;
using Pihalve.PlaylistConverter.Application.Extensions;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify
{
    public class SpotifyTrackSearcher : ITrackSearcher
    {
        private readonly string _baseSearchUrl;
        private readonly IRequestClient _requestClient;
        private readonly IRuleProcessor _ruleProcessor;
        private readonly XNamespace _ns = "http://www.spotify.com/ns/music/1";

        public SpotifyTrackSearcher(string baseSearchUrl, IRequestClient requestClient, IRuleProcessor ruleProcessor)
        {
            _baseSearchUrl = baseSearchUrl;
            _requestClient = requestClient;
            _ruleProcessor = ruleProcessor;
        }

        public async Task<IEnumerable<PlaylistItem>> FindAsync(PlaylistItem playlistItem, HashSet<BaseRule> searchRules)
        {
            if (playlistItem == null) throw new ArgumentNullException("playlistItem");

            string url = CreateUrl(playlistItem, searchRules);
            string response = await _requestClient.PerformRequestAsync(url);
            IEnumerable<XElement> tracks = ReadTrackElements(response);
            return ParseResult(tracks);
        }

        private IEnumerable<XElement> ReadTrackElements(string response)
        {
            try
            {
                XDocument spotifyResultDocument = XDocument.Parse(response);
                return spotifyResultDocument
                    .Descendants(_ns + "tracks")
                        .Descendants(_ns + "track");
            }
            catch
            {
                throw new InvalidPlaylistFormatException("Spotify");
            }
        }

        private IEnumerable<PlaylistItem> ParseResult(IEnumerable<XElement> trackElements)
        {
            var playlistItems = new List<PlaylistItem>();

            foreach (XElement track in trackElements)
            {
                var id = GetValue<string>("id", track);
                var trackName = GetValue<string>("name", track);
                var artist = GetValue<string>("name", track.Element(_ns + "artist"));
                var album = GetValue<string>("name", track.Element(_ns + "album"));
                var year = GetValue<int?>("released", track.Element(_ns + "album"));
                var territories = GetValue<string>("territories", track.Descendants(_ns + "album").First().Element(_ns + "availability"));
                XAttribute trackLink = track.Attribute("href");
                if (trackLink != null && !string.IsNullOrEmpty(trackLink.Value))
                {
                    playlistItems.Add(PlaylistItem.Create(id, artist, album, year, trackName, territories.Split(' '), trackLink.Value));
                }
            }

            return playlistItems;
        }

        private T GetValue<T>(string name, XElement trackElement)
        {
            var trackChildElement = trackElement.Element(_ns + name);
            if (trackChildElement != null)
            {
                string value = trackChildElement.Value;
                Type targetType = typeof(T);
                Type nullableType = Nullable.GetUnderlyingType(targetType);
                if (nullableType != null)
                {
                    targetType = nullableType;
                }
                return (T)Convert.ChangeType(value, targetType);
            }
            return default(T);
        }

        private string CreateUrl(PlaylistItem playlistItem, HashSet<BaseRule> rules)
        {
            var processorRules = GetProcessorRules(rules);
            PlaylistItem processedPlaylistItem = _ruleProcessor.Process(playlistItem, processorRules);

            var filterRules = GetFilterRules(rules);
            string queryString = GenerateFilter(processedPlaylistItem, filterRules);

            return string.Format("{0}?q={1}", _baseSearchUrl, queryString);
        }

        private static string GenerateFilter(PlaylistItem playlistItem, HashSet<BaseFilterRule> filterRules)
        {
            var queryString = new StringBuilder();
            foreach (BaseFilterRule rule in filterRules)
            {
                string filter = rule.GetFilter(playlistItem);
                if (!string.IsNullOrEmpty(filter))
                {
                    if (queryString.Length > 0)
                    {
                        queryString.Append("+");
                    }
                    queryString.Append(filter);
                }
            }
            return queryString.ToString();
        }

        private static HashSet<BaseProcessorRule> GetProcessorRules(IEnumerable<BaseRule> rules)
        {
            return rules.Where(x => x.Is(typeof(BaseProcessorRule))).Select(x => (BaseProcessorRule)x).ToHashSet();
        }

        private static HashSet<BaseFilterRule> GetFilterRules(IEnumerable<BaseRule> rules)
        {
            return rules.Where(x => x.Is(typeof(BaseFilterRule))).Select(x => (BaseFilterRule)x).ToHashSet();
        }
    }
}
