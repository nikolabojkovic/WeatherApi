using MediatR;
using WeatherApi.ViewModels;

namespace WeatherApi.ZipCodeForecast.Queries
{
    public class ZipCodeForecastQuery : IRequest<ForecastViewModel>
    {
        public string ZipCode { get; set; }
    }
}