using System.Collections.Generic;

namespace Pihalve.PlaylistConverter.Application.Domain
{
    public class SearchSettings
    {
        private List<FallbackItem> _fallbackSequence;

        public bool IncludeArtistInSearch { get; set; }
        public bool IncludeAlbumInSearch { get; set; }
        public bool IncludeYearInSearch { get; set; }
        public bool IncludeTrackInSearch { get; set; }

        public bool RemoveParenthesesPartsFromArtist { get; set; }
        public bool RemoveParenthesesPartsFromAlbum { get; set; }
        public bool RemoveParenthesesPartsFromTrack { get; set; }
        public bool RemoveWords { get; set; }
        public string WordsToRemove { get; set; }

        public List<FallbackItem> FallbackSequence
        {
            get { return _fallbackSequence ?? (_fallbackSequence = new List<FallbackItem>()); }
            set { _fallbackSequence = value; }
        }
    }
}
