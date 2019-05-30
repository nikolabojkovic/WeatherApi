using AutoMapper;
using WeatherApi.Domain;
using WeatherApi.ViewModels;

namespace WeatherApi.Profiles 
{
    public class WeatherProfile : Profile
    {
        public WeatherProfile() 
        {
            CreateMap<Weather, WeatherViewModel>();
        }
    }
}