using MediatR;
using WeatherApi.ViewModels;

namespace WeatherApi.CityForecast.Queries
{
    public class CityCurrentWeatherQuery : IRequest<WeatherViewModel>
    {
        public string CityName { get; set; }
    }
}