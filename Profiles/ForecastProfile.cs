using AutoMapper;
using WeatherApi.Domain;
using WeatherApi.ViewModels;

namespace WeatherApi.Profiles 
{
    public class ForecastProfile : Profile
    {
        public ForecastProfile() 
        {
            CreateMap<Forecast, ForecastViewModel>();
            CreateMap<Weather, ForecastWeatherViewModel>();
        }
    }
}