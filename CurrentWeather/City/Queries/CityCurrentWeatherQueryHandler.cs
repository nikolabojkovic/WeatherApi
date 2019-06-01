using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Core;
using WeatherApi.Domain;
using WeatherApi.DTO;
using WeatherApi.ViewModels;

namespace WeatherApi.CityForecast.Queries
{
    public class CityCurrentWeatherQueryHandler : IRequestHandler<CityCurrentWeatherQuery, WeatherViewModel>
    {
        private readonly IRouter _router;
        private readonly IConfiguration _configuration;
        private readonly string _units;

        public CityCurrentWeatherQueryHandler(IRouter router, IConfiguration configuration) {
            _router = router;
            _configuration = configuration;
            _units = _configuration.GetSection("WeatherSettings")["units"];
        }

        public async Task<WeatherViewModel> Handle(CityCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?q={request.CityName}&units={_units}", cancellationToken);
            WeatherContainerDTO weatherApiData = JsonConvert.DeserializeObject<WeatherContainerDTO>(apiWeatherDataString);

            return Mapper.Map<Weather, WeatherViewModel>(Weather.SuppliedFrom(weatherApiData));
        }
    }
}