using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pihalve.PlaylistConverter.Application.Domain;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public static class FallbackItemFactory
    {
        public static List<FallbackItem> Create(StringCollection fallbackSequence)
        {
            var list = new List<FallbackItem>();
            foreach (var item in fallbackSequence)
            {
                string[] parts = item.Split(';');
                var fallbackItem = new FallbackItem(GetRuleType(parts[0]), GetActiveValue(parts[1]));
                if (fallbackItem.Active)
                {
                    list.Add(fallbackItem);
                }
            }
            return list;
        }

        private static Type GetRuleType(string typeName)
        {
            return Type.GetType(typeName);
        }

        private static bool GetActiveValue(string value)
        {
            return bool.Parse(value);
        }
    }
}
