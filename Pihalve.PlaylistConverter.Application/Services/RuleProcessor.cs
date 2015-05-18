using System.Collections.Generic;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public class RuleProcessor : IRuleProcessor
    {
        public PlaylistItem Process(PlaylistItem playlistItem, HashSet<BaseProcessorRule> processorRules)
        {
            var clone = (PlaylistItem)playlistItem.Clone();
            foreach (BaseProcessorRule rule in processorRules)
            {
                rule.Apply(clone);
            }
            return clone;
        }

        public PlaylistItem Process(PlaylistItem playlistItem, BaseProcessorRule processorRule)
        {
            var clone = (PlaylistItem)playlistItem.Clone();
            processorRule.Apply(clone);
            return clone;
        }
    }
}
