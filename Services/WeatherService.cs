
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Core;
using WeatherApi.Domain;

namespace WeatherApi.CustomServices {
    public class WeatherService : IWeatherService {
        
        private readonly IRouter _router;

        public WeatherService(IRouter router) {
            _router = router;
        }

        public async Task<Weather> ForcastByNameOfThe(string city) {

            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"data/2.5/weather?q={city}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);
            
            return Weather.SupplyFrom(dynamicApiData);
        }
    }
}