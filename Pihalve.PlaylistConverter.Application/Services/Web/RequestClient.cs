using System;
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

        public async Task<string> PerformRequestAsync(string uri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
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
