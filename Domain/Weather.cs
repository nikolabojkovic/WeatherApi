
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherApi.Domain {
    public class Weather {

        private Weather(string condition, 
                        string description, 
                        string icon,
                        decimal temperature, 
                        int humidity, 
                        decimal windSpeed,
                        DateTime dateTime) {
            Condition = condition;
            Description = description;
            Icon = icon;
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
            AtDateTime = dateTime;
        }

        private Weather() {}

        public string Condition { get; private set; }
        public string Description { get; private set; }
        public decimal Temperature { get; private set; }
        public int Humidity { get; private set; }
        public decimal WindSpeed { get; private set; }
        public string Icon { get; set; }
        public DateTime AtDateTime { get; private set; }

        internal static Weather CreateFrom(IEnumerable<Weather> segments)
        {
            var averageTemp = segments.Aggregate(decimal.Zero, (acc, x) => acc + x.Temperature) / segments.Count();
            var avarageHumidity = segments.Aggregate(decimal.Zero, (acc, x) => acc + x.Humidity) / segments.Count();
            var avarageWindSpeed = segments.Aggregate(decimal.Zero, (acc, x) => acc + x.WindSpeed) / segments.Count();

            return new Weather() {
                Condition = segments.First().Condition,                
                Description = segments.First().Description,
                // take day icon
                Icon = segments.Skip(2).First().Icon,
                Temperature = averageTemp,
                Humidity = Convert.ToInt32(avarageHumidity),
                WindSpeed = avarageWindSpeed,
                AtDateTime = segments.First().AtDateTime
            };
        }

        public static Weather SuppliedFrom(dynamic apiWeatherData) {
            var tempNode = apiWeatherData?.main?.temp;
            var humidityNode = apiWeatherData?.main?.humidity;
            var windSpeedNode = apiWeatherData?.wind?.speed;

            var weatherNode = apiWeatherData?.weather != null && apiWeatherData?.weather?.Count > 0 
                            ? apiWeatherData?.weather[0] : null;

            return new Weather(weatherNode != null ? weatherNode.main?.Value.ToString() : string.Empty, 
                               weatherNode != null ? weatherNode.description?.Value.ToString() : string.Empty,
                               weatherNode != null ? weatherNode.icon?.Value.ToString() : string.Empty,
                               tempNode != null ? Convert.ToDecimal(tempNode.Value) : 0,
                               humidityNode != null ? Convert.ToInt32(humidityNode.Value) : 0,
                               windSpeedNode != null ? Convert.ToDecimal(windSpeedNode.Value) : 0,
                               Convert.ToDateTime(apiWeatherData.dt_txt));
        }
    }
}