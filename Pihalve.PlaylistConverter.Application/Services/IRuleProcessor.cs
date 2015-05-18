using System.Collections.Generic;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface IRuleProcessor
    {
        PlaylistItem Process(PlaylistItem playlistItem, HashSet<BaseProcessorRule> processorRules);
        PlaylistItem Process(PlaylistItem playlistItem, BaseProcessorRule processorRules);
    }
}
