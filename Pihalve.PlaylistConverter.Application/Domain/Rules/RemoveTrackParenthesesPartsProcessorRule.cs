namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public class RemoveTrackParenthesesPartsProcessorRule : BaseParenthesesPartsProcessorRule
    {
        public RemoveTrackParenthesesPartsProcessorRule(bool active)
            : base(active)
        {
        }

        public override void Apply(PlaylistItem playlistItem)
        {
            playlistItem.Track.Name = RemoveParenthesesParts(playlistItem.Track.Name);
        }
    }
}
