namespace Pihalve.PlaylistConverter.Application.Services
{
    public class BasicAuthToken : AuthToken
    {
        public BasicAuthToken(string credentials)
        {
            Scheme = "Basic";
            Credentials = credentials;
        }
    }
}
