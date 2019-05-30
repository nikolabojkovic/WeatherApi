using System.Collections.Generic;

namespace WeatherApi.ViewModels
{
    public class ForecastViewModel 
    {
        public List<ForecastWeatherViewModel> Days { get; private set; }
        public string City { get; private set; }
    }
}