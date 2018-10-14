using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly ITokenRetriever _tokenRetriever;

        public SpotifyTrackSearcher(string baseSearchUrl, IRequestClient requestClient, IRuleProcessor ruleProcessor, ITokenRetriever tokenRetriever)
        {
            _baseSearchUrl = baseSearchUrl;
            _requestClient = requestClient;
            _ruleProcessor = ruleProcessor;
            _tokenRetriever = tokenRetriever;
        }

        public async Task<IEnumerable<PlaylistItem>> FindAsync(PlaylistItem playlistItem, HashSet<BaseRule> searchRules)
        {
            if (playlistItem == null) throw new ArgumentNullException("playlistItem");

            string url = CreateUrl(playlistItem, searchRules);
            var authToken = await _tokenRetriever.GetToken();
            string response = await _requestClient.GetAsync(url, authToken);
            var pagingObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response);

            try
            {
                var tracks = ParseResult(pagingObject);
                return tracks;
            }
            catch (Exception ex)
            {
                throw new InvalidPlaylistFormatException("Spotify", ex);
            }
        }

        private IEnumerable<PlaylistItem> ParseResult(dynamic pagingObject)
        {
            var playlistItems = new List<PlaylistItem>();

            foreach (var track in pagingObject.tracks.items)
            {
                playlistItems.Add(PlaylistItem.Create(
                    (string)track.id,
                    (string)track.artists[0].name,
                    (string)track.album.name,
                    GetYear((string)track.album.release_date, (string)track.album.release_date_precision),
                    (string)track.name,
                    Enumerable.Empty<string>(),
                    (string)track.href));
            }

            return playlistItems;
        }

        private static int? GetYear(string releaseDate, string releaseDatePrecision)
        {
            switch (releaseDatePrecision)
            {
                case "year":
                    return int.Parse(releaseDate);
                case "month":
                    return DateTime.ParseExact(releaseDate, "yyyy-MM", CultureInfo.InvariantCulture).Year;
                case "day":
                    return DateTime.ParseExact(releaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).Year;
                default:
                    throw new FormatException($"Unsupported format for {nameof(releaseDate)}");
            }
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

            if (queryString.Length > 0)
            {
                queryString.Append("&type=track");
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
