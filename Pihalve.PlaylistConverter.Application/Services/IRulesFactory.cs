using System.Collections.Generic;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface IRulesFactory
    {
        HashSet<BaseRule> Create(SearchSettings searchSettings);
    }
}