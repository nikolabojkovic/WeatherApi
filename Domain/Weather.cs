
using System;

namespace WeatherApi.Domain {
    public class Weather {

        private Weather(string condition, 
                        string description, 
                        decimal temperature, 
                        int humidity, 
                        decimal windSpeed,
                        DateTime dateTime) {
            Condition = condition;
            Description = description;
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
            DateTime = dateTime;
        }

        private Weather() {}

        public string Condition { get; private set; }
        public string Description { get; private set; }
        public decimal Temperature { get; private set; }
        public int Humidity { get; private set; }
        public decimal WindSpeed { get; private set; }
        public DateTime DateTime { get; private set; }


        public static Weather SuppliedFrom(dynamic apiWeatherData) {
            var tempNode = apiWeatherData?.main?.temp;
            var humidityNode = apiWeatherData?.main?.humidity;
            var windSpeedNode = apiWeatherData?.wind?.speed;

            var weatherNode = apiWeatherData?.weather != null && apiWeatherData?.weather?.Count > 0 
                            ? apiWeatherData?.weather[0] : null;

            return new Weather(weatherNode != null ? weatherNode.main?.Value.ToString() : string.Empty, 
                               weatherNode != null ? weatherNode.description?.Value.ToString() : string.Empty,
                               tempNode != null ? Convert.ToDecimal(tempNode.Value) : 0,
                               humidityNode != null ? Convert.ToInt32(humidityNode.Value) : 0,
                               windSpeedNode != null ? Convert.ToDecimal(windSpeedNode.Value) : 0,
                               Convert.ToDateTime(apiWeatherData.dt_txt));
        }
    }
}