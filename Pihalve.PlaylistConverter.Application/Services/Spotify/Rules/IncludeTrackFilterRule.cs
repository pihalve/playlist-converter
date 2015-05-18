using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify.Rules
{
    public class IncludeTrackFilterRule : BaseSpotifyFilterRule
    {
        public IncludeTrackFilterRule(bool include)
            : base(include)
        {
        }

        public override string GetFilter(PlaylistItem playlistItem)
        {
            if (Active)
            {
                if (!string.IsNullOrEmpty(playlistItem.Track.Name))
                {
                    return string.Format("track:{0}", EncodeString(playlistItem.Track.Name));
                }
            }
            return null;
        }
    }
}
