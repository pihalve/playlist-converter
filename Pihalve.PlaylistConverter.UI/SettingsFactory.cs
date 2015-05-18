using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Services;
using Pihalve.PlaylistConverter.UI.Properties;

namespace Pihalve.PlaylistConverter.UI
{
    internal static class SettingsFactory
    {
        internal static SearchSettings Create(Settings settings)
        {
            return new SearchSettings
                {
                    IncludeArtistInSearch = settings.IncludeArtistInSearch,
                    IncludeAlbumInSearch = settings.IncludeAlbumInSearch,
                    IncludeYearInSearch = settings.IncludeYearInSearch,
                    IncludeTrackInSearch = settings.IncludeTrackInSearch,
                    RemoveParenthesesPartsFromArtist = settings.RemoveParenthesesPartsFromArtist,
                    RemoveParenthesesPartsFromAlbum = settings.RemoveParenthesesPartsFromAlbum,
                    RemoveParenthesesPartsFromTrack = settings.RemoveParenthesesPartsFromTrack,
                    WordsToRemove = settings.WordsToRemove,
                    FallbackSequence = FallbackItemFactory.Create(settings.FallbackSequence)
                };
        }
    }
}
