using System;

namespace WeatherApi.ViewModels
{
    public class ForecastWeatherViewModel 
    {
        public string Condition { get; private set; }
        public string Description { get; private set; }
        public decimal Temperature { get; private set; }
        public int Humidity { get; private set; }
        public decimal WindSpeed { get; private set; }
        public string Icon { get; private set; }
        public DateTime AtDateTime { get; private set; }
    }
}