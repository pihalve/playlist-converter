using System;

namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public abstract class BaseRule
    {
        public bool Active { get; set; }

        protected BaseRule(bool active)
        {
            Active = active;
        }

        public bool Is(Type type)
        {
            return GetType().IsSubclassOf(type);
        }

        public static bool Is(Type thisType, Type thatType)
        {
            return thisType.IsSubclassOf(thatType);
        }
    }
}
