
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Core;
using WeatherApi.Domain;

namespace WeatherApi.CustomServices {
    public class WeatherService : IWeatherService {
        
        private readonly IRouter _router;
        public string Units { get; set; } = "metric";

        public WeatherService(IRouter router) {
            _router = router;
        }

        public async Task<Forecast> ForcastByCity(string city) {

            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?q={city}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);

            return Forecast.SuppliedFrom(dynamicApiData);
        }

        public async Task<Forecast> ForcastByZipCode(string code)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?zip={code}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);
            
            return Forecast.SuppliedFrom(dynamicApiData);
        }

        public async Task<Weather> WeatherByCity(string city)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?q={city}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);

            return Weather.SuppliedFrom(dynamicApiData);
        }

        public async Task<Weather> WeatherByZipCode(string code)
        {
             var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?zip={code}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);
            
            return Weather.SuppliedFrom(dynamicApiData);
        }
    }
}