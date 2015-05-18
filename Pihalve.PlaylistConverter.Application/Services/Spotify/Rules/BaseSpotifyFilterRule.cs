using System.Web;
using Pihalve.PlaylistConverter.Application.Domain.Rules;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify.Rules
{
    public abstract class BaseSpotifyFilterRule : BaseFilterRule
    {
        protected BaseSpotifyFilterRule(bool include)
            : base(include)
        {
        }

        public static string EncodeString(string value)
        {
            return HttpUtility.UrlEncode(value.Trim()).Replace("%20", "+");
        }
    }
}
