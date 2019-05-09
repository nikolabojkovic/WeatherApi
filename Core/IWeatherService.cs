using System.Threading.Tasks;
using WeatherApi.Domain;

namespace WeatherApi.Core {

    public interface IWeatherService
    {
        Task<Weather> ForcastByNameOfThe(string cityName);
    }
}