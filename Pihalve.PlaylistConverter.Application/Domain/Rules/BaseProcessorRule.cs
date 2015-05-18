namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public abstract class BaseProcessorRule : BaseRule
    {
        protected BaseProcessorRule(bool active)
            : base(active)
        {
        }

        public abstract void Apply(PlaylistItem playlistItem);
    }
}
