using System.Collections.Generic;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;
using Pihalve.PlaylistConverter.Application.Services.Spotify.Rules;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify
{
    public class SpotifyRulesFactory : IRulesFactory
    {
        public HashSet<BaseRule> Create(SearchSettings searchSettings)
        {
            var rules = new HashSet<BaseRule>();
            rules.Add(new IncludeArtistFilterRule(searchSettings.IncludeArtistInSearch));
            rules.Add(new IncludeAlbumFilterRule(searchSettings.IncludeAlbumInSearch));
            rules.Add(new IncludeYearFilterRule(searchSettings.IncludeYearInSearch));
            rules.Add(new IncludeTrackFilterRule(searchSettings.IncludeTrackInSearch));
            rules.Add(new RemoveArtistParenthesesPartsProcessorRule(searchSettings.RemoveParenthesesPartsFromArtist));
            rules.Add(new RemoveAlbumParenthesesPartsProcessorRule(searchSettings.RemoveParenthesesPartsFromAlbum));
            rules.Add(new RemoveTrackParenthesesPartsProcessorRule(searchSettings.RemoveParenthesesPartsFromTrack));
            rules.Add(new RemoveWordsProcessorRule(searchSettings.RemoveWords, searchSettings.WordsToRemove));
            return rules;
        }
    }
}
