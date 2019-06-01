using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WeatherApi.Core;

namespace WeatherApi.Infrastructure {

    public class Router: IRouter {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public Router(IConfiguration configurtion, IHttpClientFactory clientFactory) {
            _configuration = configurtion;
            _clientFactory = clientFactory;
        }

        public async Task<string> SendKeepAliveRequest(CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _configuration.GetSection("KeepAlive")["hostTargetUrl"]);
            var response = await _clientFactory.CreateClient().SendAsync(request, cancellationToken);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SendRequest(HttpMethod method, string parameters, CancellationToken cancellationToken)
        {
            var appId = $"&appid={_configuration.GetSection("RemoteWeatherApi")["appId"]}";
            var response = await _clientFactory.CreateClient("openWeatherApi")
                                               .SendAsync(new HttpRequestMessage(method, $"{parameters}{appId}"),
                                                          cancellationToken);

            return await response.Content.ReadAsStringAsync();
        }
    }
}