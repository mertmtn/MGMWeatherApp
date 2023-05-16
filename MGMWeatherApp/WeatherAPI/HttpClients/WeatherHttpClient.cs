using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using WeatherAPI.Models.Options;

namespace WeatherAPI.HttpClients
{
    public class WeatherHttpClient : HttpClientBase
    {
        private HttpClient _httpClient { get; }
        private OpenWeatherMapApiInfo _apiInfo { get; }

        public WeatherHttpClient(HttpClient httpClient, IOptions<OpenWeatherMapApiInfo> _options)
        {
            _httpClient = httpClient;
            _apiInfo = _options.Value;
            httpClient.BaseAddress = new Uri(_apiInfo.BaseUrl);            
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<string> GetAsync(string url)
        {
            return HttpClientGetAsync(url, _httpClient);
        }
    }
}