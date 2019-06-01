using MediatR;
using WeatherApi.ViewModels;

namespace WeatherApi.ZipCodeForecast.Queries
{
    public class ZipCodeCurrentWeatherQuery : IRequest<WeatherViewModel>
    {
        public string ZipCode { get; set; }
    }
}