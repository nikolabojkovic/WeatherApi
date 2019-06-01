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
    public class CityForecastQueryHandler : IRequestHandler<CityForecastQuery, ForecastViewModel>
    {
        private readonly IRouter _router;
        private readonly IConfiguration _configuration;
        private readonly string _units;

        public CityForecastQueryHandler(IRouter router, IConfiguration configuration) {
            _router = router;
            _configuration = configuration;
            _units = _configuration.GetSection("WeatherSettings")["units"];
        }

        public async Task<ForecastViewModel> Handle(CityForecastQuery request, CancellationToken cancellationToken)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?q={request.CityName}&units={_units}", cancellationToken);
            ForecastContainerDTO weatherApiData = JsonConvert.DeserializeObject<ForecastContainerDTO>(apiWeatherDataString);

            return Mapper.Map<Forecast, ForecastViewModel>(Forecast.SuppliedFrom(weatherApiData));
        }
    }
}