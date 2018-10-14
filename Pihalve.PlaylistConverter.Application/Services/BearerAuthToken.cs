using System;

namespace Pihalve.PlaylistConverter.Application.Services
{
    public class BearerAuthToken : AuthToken
    {
        public BearerAuthToken(string credentials, DateTime expires)
        {
            Scheme = "Bearer";
            Credentials = credentials;
            Expires = expires;
        }

        public DateTime Expires { get; private set; }
    }
}
