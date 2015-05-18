namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public class RemoveArtistParenthesesPartsProcessorRule : BaseParenthesesPartsProcessorRule
    {
        public RemoveArtistParenthesesPartsProcessorRule(bool active)
            : base(active)
        {
        }

        public override void Apply(PlaylistItem playlistItem)
        {
            playlistItem.Artist.Name = RemoveParenthesesParts(playlistItem.Artist.Name);
        }
    }
}
