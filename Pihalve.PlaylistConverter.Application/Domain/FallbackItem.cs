using System;

namespace Pihalve.PlaylistConverter.Application.Domain
{
    public class FallbackItem
    {
        public FallbackItem(Type ruleType, bool active)
        {
            RuleType = ruleType;
            Active = active;
        }

        public Type RuleType { get; set; }
        public bool Active { get; set; }
    }
}
