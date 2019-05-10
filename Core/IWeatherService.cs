using System.Threading.Tasks;
using WeatherApi.Domain;

namespace WeatherApi.Core {

    public interface IWeatherService
    {
        Task<Forcast> ForcastByNameOfThe(string cityName);
    }
}