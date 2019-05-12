using System.Threading.Tasks;
using WeatherApi.Domain;

namespace WeatherApi.Core {

    public interface IWeatherService
    {
        Task<Weather> WeatherByNameOfThe(string cityName);
        Task<Weather> WeatherByZipCode(string code);
        Task<Forecast> ForcastByNameOfThe(string cityName);
        Task<Forecast> ForcastByZip(string code);
    }
}