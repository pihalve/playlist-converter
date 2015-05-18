using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify.Rules
{
    public class IncludeYearFilterRule : BaseSpotifyFilterRule
    {
        public IncludeYearFilterRule(bool include)
            : base(include)
        {
        }

        public override string GetFilter(PlaylistItem playlistItem)
        {
            if (Active)
            {
                if (playlistItem.Album.Year.HasValue)
                {
                    return string.Format("year:{0}", playlistItem.Album.Year);
                }
            }
            return null;
        }
    }
}
