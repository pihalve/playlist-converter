using System.Threading.Tasks;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface IRequestClient
    {
        Task<string> PerformRequestAsync(string uri);
    }
}
