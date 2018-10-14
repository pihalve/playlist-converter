using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface IRequestClient
    {
        Task<string> GetAsync(string uri, AuthToken authToken);
        Task<string> PostAsync(string uri, IDictionary<string, string> formParameters, AuthToken authToken);
    }
}
