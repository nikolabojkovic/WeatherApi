using MediatR;
using WeatherApi.ViewModels;

namespace WeatherApi.CityForecast.Queries
{
    public class CityForecastQuery : IRequest<ForecastViewModel>
    {
        public string CityName { get; set; }
    }
}