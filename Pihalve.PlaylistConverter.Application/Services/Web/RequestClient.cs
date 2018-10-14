using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pihalve.PlaylistConverter.Application.Exceptions;

namespace Pihalve.PlaylistConverter.Application.Services.Web
{
    public class RequestClient : IRequestClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public RequestClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string uri, AuthToken authToken)
        {
            if (authToken == null) throw new ArgumentNullException(nameof(authToken));

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authToken.Scheme, authToken.Credentials);
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestFailedException(string.Format("Request failed with status code: {0}", response.StatusCode));
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> PostAsync(string uri, IDictionary<string, string> formParameters, AuthToken authToken)
        {
            if (authToken == null) throw new ArgumentNullException(nameof(authToken));

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authToken.Scheme, authToken.Credentials);
            HttpResponseMessage response = await _httpClient.PostAsync(uri, new FormUrlEncodedContent(formParameters));
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestFailedException(string.Format("Request failed with status code: {0}", response.StatusCode));
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
