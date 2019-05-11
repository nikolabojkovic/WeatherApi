using System.Threading.Tasks;
using WeatherApi.Domain;

namespace WeatherApi.Core {

    public interface IWeatherService
    {
        Task<Forecast> ForcastByNameOfThe(string cityName);
        Task<Forecast> ForcastByZip(string code);
    }
}