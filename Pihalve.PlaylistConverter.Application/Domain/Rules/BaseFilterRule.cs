namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public abstract class BaseFilterRule : BaseRule
    {
        protected BaseFilterRule(bool active)
            : base(active)
        {
        }

        public abstract string GetFilter(PlaylistItem playlistItem);
    }
}
