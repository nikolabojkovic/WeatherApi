using System.Threading.Tasks;
using WeatherApi.Domain;
using WeatherApi.ViewModels;

namespace WeatherApi.Core {

    public interface IWeatherService
    {
        Task<WeatherViewModel> WeatherByCity(string cityName);
        Task<WeatherViewModel> WeatherByZipCode(string code);
        Task<ForecastViewModel> ForcastByCity(string cityName);
        Task<ForecastViewModel> ForcastByZipCode(string code);
    }
}