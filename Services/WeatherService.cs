
using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Core;
using WeatherApi.Domain;
using WeatherApi.DTO;
using WeatherApi.ViewModels;

namespace WeatherApi.CustomServices {
    public class WeatherService : IWeatherService {
        
        private readonly IRouter _router;
        public string Units { get; set; } = "metric";

        public WeatherService(IRouter router) {
            _router = router;
        }

        public async Task<ForecastViewModel> ForcastByCity(string city) {

            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?q={city}&units={Units}");
            ForecastContainerDTO weatherApiData = JsonConvert.DeserializeObject<ForecastContainerDTO>(apiWeatherDataString);

            return Mapper.Map<Forecast, ForecastViewModel>(Forecast.SuppliedFrom(weatherApiData));
        }

        public async Task<ForecastViewModel> ForcastByZipCode(string code)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?zip={code}&units={Units}");
            ForecastContainerDTO weatherApiData = JsonConvert.DeserializeObject<ForecastContainerDTO>(apiWeatherDataString);
            
            return Mapper.Map<Forecast, ForecastViewModel>(Forecast.SuppliedFrom(weatherApiData));
        }

        public async Task<WeatherViewModel> WeatherByCity(string city)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?q={city}&units={Units}");
            WeatherContainerDTO weatherApiData = JsonConvert.DeserializeObject<WeatherContainerDTO>(apiWeatherDataString);

            return Mapper.Map<Weather, WeatherViewModel>(Weather.SuppliedFrom(weatherApiData));
        }

        public async Task<WeatherViewModel> WeatherByZipCode(string code)
        {
             var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?zip={code}&units={Units}");
            WeatherContainerDTO weatherApiData = JsonConvert.DeserializeObject<WeatherContainerDTO>(apiWeatherDataString);
            
            return Mapper.Map<Weather, WeatherViewModel>(Weather.SuppliedFrom(weatherApiData));
        }
    }
}