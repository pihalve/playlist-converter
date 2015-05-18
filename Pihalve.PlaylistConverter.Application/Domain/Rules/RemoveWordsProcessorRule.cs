using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pihalve.PlaylistConverter.Application.Extensions;

namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public class RemoveWordsProcessorRule : BaseProcessorRule
    {
        private IEnumerable<string> _wordsToRemove;

        private IEnumerable<string> WordsToRemove
        {
            get { return _wordsToRemove ?? (_wordsToRemove = Enumerable.Empty<string>()); }
            set { _wordsToRemove = value; }
        }

        public RemoveWordsProcessorRule(bool active, string wordsToRemove)
            : base(active)
        {
            if (!string.IsNullOrEmpty(wordsToRemove))
            {
                WordsToRemove = wordsToRemove.Split(' ');
            }
        }

        public override void Apply(PlaylistItem playlistItem)
        {
            playlistItem.Artist.Name = RemoveWords(playlistItem.Artist.Name);
            playlistItem.Album.Name = RemoveWords(playlistItem.Album.Name);
            playlistItem.Track.Name = RemoveWords(playlistItem.Track.Name);
        }

        private string RemoveWords(string value)
        {
            if (value != null)
            {
                foreach (string word in WordsToRemove)
                {
                    value = value.Remove(word, CompareOptions.IgnoreCase);
                }
            }
            return value;
        }
    }
}
