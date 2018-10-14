using System.Threading.Tasks;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public interface ITokenRetriever
    {
        Task<BearerAuthToken> GetToken();
    }
}
