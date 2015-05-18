using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify.Rules
{
    public class IncludeAlbumFilterRule : BaseSpotifyFilterRule
    {
        public IncludeAlbumFilterRule(bool include)
            : base(include)
        {
        }

        public override string GetFilter(PlaylistItem playlistItem)
        {
            if (Active)
            {
                if (!string.IsNullOrEmpty(playlistItem.Album.Name))
                {
                    return string.Format("album:{0}", EncodeString(playlistItem.Album.Name));
                }
            }
            return null;
        }
    }
}
