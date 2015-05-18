namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public class RemoveAlbumParenthesesPartsProcessorRule : BaseParenthesesPartsProcessorRule
    {
        public RemoveAlbumParenthesesPartsProcessorRule(bool active)
            : base(active)
        {
        }

        public override void Apply(PlaylistItem playlistItem)
        {
            playlistItem.Album.Name = RemoveParenthesesParts(playlistItem.Album.Name);
        }
    }
}
