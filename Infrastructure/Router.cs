using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WeatherApi.Core;

namespace WeatherApi.Infrastructure {

    public class Router: IRouter {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public Router(IConfiguration configurtion) {
            _configuration = configurtion;
            _client = new HttpClient();
        }

        public async Task<string> SendKeepAliveRequest()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _configuration.GetSection("KeepAlive")["hostTargetUrl"]);
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SendRequest(HttpMethod method, string parameters)
        {
            var api = _configuration.GetSection("RemoteWeatherApi")["apiUri"];
            var appId = $"&appid={_configuration.GetSection("RemoteWeatherApi")["appId"]}";

            HttpRequestMessage request = new HttpRequestMessage(method, $"{api}{parameters}{appId}");
            var response = await _client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}