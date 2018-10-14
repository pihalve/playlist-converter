using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pihalve.PlaylistConverter.Application.Services.Spotify
{
    public class SpotifyTokenRetriever : ITokenRetriever
    {
        private readonly string _accountsServiceUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly IRequestClient _requestClient;
        private BearerAuthToken _authToken;

        public SpotifyTokenRetriever(string accountsServiceUrl, string clientId, string clientSecret, IRequestClient requestClient)
        {
            _accountsServiceUrl = accountsServiceUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _requestClient = requestClient;
        }

        public async Task<BearerAuthToken> GetToken()
        {
            if (_authToken == null || _authToken.Expires <= DateTime.Now)
            {
                var credentials = Base64Encode($"{_clientId}:{_clientSecret}");
                var authToken = new BasicAuthToken(credentials);
                var formParameters = new Dictionary<string, string> {{"grant_type", "client_credentials"}};
                string response = await _requestClient.PostAsync(_accountsServiceUrl, formParameters, authToken);
                _authToken = CreateBearerAuthToken(response);
            }

            return _authToken;
        }

        private static BearerAuthToken CreateBearerAuthToken(string json)
        {
            var responseToken = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
            return new BearerAuthToken((string)responseToken.access_token, DateTime.Now.AddSeconds((int)responseToken.expires_in));
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
