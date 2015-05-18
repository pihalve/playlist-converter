using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify.Rules
{
    public class IncludeArtistFilterRule : BaseSpotifyFilterRule
    {
        public IncludeArtistFilterRule(bool include)
            : base(include)
        {
        }

        public override string GetFilter(PlaylistItem playlistItem)
        {
            if (Active)
            {
                if (!string.IsNullOrEmpty(playlistItem.Artist.Name))
                {
                    return string.Format("artist:{0}", EncodeString(playlistItem.Artist.Name));
                }
            }
            return null;
        }
    }
}
