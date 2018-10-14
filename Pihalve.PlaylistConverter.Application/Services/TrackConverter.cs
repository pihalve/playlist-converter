using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;
using Pihalve.PlaylistConverter.Application.Extensions;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public class TrackConverter : ITrackConverter
    {
        private readonly int _requestsPerSecond;
        private readonly ITrackSearcher _trackSearcher;
        public event EventHandler<TrackConvertionEventArgs> TrackConvertedEvent;
        public delegate void TrackConvertedEventHandler(object sender, TrackConvertionEventArgs e);
        public event EventHandler TracksConvertedEvent;
        public delegate void TracksConvertedEventHandler(object sender, EventArgs e);

        public TrackConverter(int requestsPerSecond, ITrackSearcher trackSearcher)
        {
            _requestsPerSecond = requestsPerSecond;
            _trackSearcher = trackSearcher;
        }

        public async void ConvertAsync(IEnumerable<PlaylistItem> playlistItems, HashSet<BaseRule> rules, List<FallbackItem> fallbackSequence)
        {
            if (playlistItems == null) throw new ArgumentNullException("playlistItems");
            if (rules == null) throw new ArgumentNullException("rules");
            if (fallbackSequence == null) throw new ArgumentNullException("fallbackSequence");

            HashSet<BaseRule> activeRules = rules.Where(x => x.Active).ToHashSet();
            foreach (PlaylistItem playlistItem in playlistItems)
            {
                IEnumerable<PlaylistItem> foundTracks = await _trackSearcher.FindAsync(playlistItem, activeRules);
                IEnumerable<PlaylistItem> tracks = foundTracks.ToList();
                if (!tracks.Any())
                {
                    foreach (var fallbackItem in fallbackSequence)
                    {
                        Type fallbackRuleType = fallbackItem.RuleType;
                        activeRules = GetRulesForFallbackSearch(rules, activeRules, fallbackRuleType);
                        foundTracks = await _trackSearcher.FindAsync(playlistItem, activeRules);
                        tracks = foundTracks.ToList();
                        if (tracks.Any())
                        {
                            break;
                        }
                        Wait();
                    }
                }

                PlaylistItem earliestTrack = tracks.OrderBy(x => x.Album.Year).FirstOrDefault();
                OnTrackConverted(earliestTrack, playlistItem);
                Wait();
            }

            OnTracksConverted();
        }

        private static HashSet<BaseRule> GetRulesForFallbackSearch(HashSet<BaseRule> allRules, HashSet<BaseRule> activeRules, Type fallbackRuleType)
        {
            HashSet<BaseRule> rulesForFallbackSearch = activeRules;
            if (BaseRule.Is(fallbackRuleType, typeof(BaseFilterRule)))
            {
                rulesForFallbackSearch = rulesForFallbackSearch.Except(allRules.Where(x => x.GetType() == fallbackRuleType)).ToHashSet();
            }
            else if (BaseRule.Is(fallbackRuleType, typeof(BaseProcessorRule)))
            {
                if (rulesForFallbackSearch.All(x => x.GetType() != fallbackRuleType))
                {
                    rulesForFallbackSearch.Add(allRules.Single(x => x.GetType() == fallbackRuleType));
                }
            }
            return rulesForFallbackSearch;
        }

        private void Wait()
        {
            if (_requestsPerSecond > 0)
            {
                Thread.Sleep(1000 / _requestsPerSecond);
            }
        }

        private void OnTrackConverted(PlaylistItem convertedTrack, PlaylistItem originalTrack)
        {
            EventHandler<TrackConvertionEventArgs> handler = TrackConvertedEvent;
            if (handler != null)
            {
                handler(this, new TrackConvertionEventArgs(convertedTrack, originalTrack));
            }
        }

        private void OnTracksConverted()
        {
            EventHandler handler = TracksConvertedEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
