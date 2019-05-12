using System.Threading.Tasks;
using WeatherApi.Domain;

namespace WeatherApi.Core {

    public interface IWeatherService
    {
        Task<Weather> WeatherByCity(string cityName);
        Task<Weather> WeatherByZipCode(string code);
        Task<Forecast> ForcastByCity(string cityName);
        Task<Forecast> ForcastByZipCode(string code);
    }
}