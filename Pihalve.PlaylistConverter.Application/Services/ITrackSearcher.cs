using System.Collections.Generic;
using System.Threading.Tasks;
using Pihalve.PlaylistConverter.Application.Domain;
using Pihalve.PlaylistConverter.Application.Domain.Rules;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface ITrackSearcher
    {
        Task<IEnumerable<PlaylistItem>> FindAsync(PlaylistItem playlistItem, HashSet<BaseRule> searchRules);
    }
}
