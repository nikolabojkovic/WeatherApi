
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WeatherApi.DTO;
using WeatherApi.Exceptions;

namespace WeatherApi.Domain {
    public class Weather {

        private Weather(string cityName, 
                        string condition,
                        string description, 
                        string icon,
                        decimal temperature, 
                        int humidity, 
                        decimal windSpeed,
                        DateTime dateTime) {
            CityName = cityName;
            Condition = condition;
            Description = description;
            Icon = icon;
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
            AtDateTime = dateTime;
        }

        private Weather() {}

        public string CityName { get; private set; }
        public string Condition { get; private set; }
        public string Description { get; private set; }
        public decimal Temperature { get; private set; }
        public int Humidity { get; private set; }
        public decimal WindSpeed { get; private set; }
        public string Icon { get; private set; }
        public DateTime AtDateTime { get; private set; }

        internal static Weather CreateFrom(IEnumerable<Weather> segments)
        {
            var averageTemp =      segments.Aggregate(decimal.Zero, (acc, x) => acc + x.Temperature) / segments.Count();
            var avarageHumidity =  segments.Aggregate(decimal.Zero, (acc, x) => acc + x.Humidity) / segments.Count();
            var avarageWindSpeed = segments.Aggregate(decimal.Zero, (acc, x) => acc + x.WindSpeed) / segments.Count();

            return new Weather() {
                Condition =   segments.First().Condition,                
                Description = segments.First().Description,
                Icon =        segments.First().Icon.Replace("n", "d"),
                Temperature = averageTemp,
                Humidity =    Convert.ToInt32(avarageHumidity),
                WindSpeed =   avarageWindSpeed,
                AtDateTime =  segments.First().AtDateTime
            };
        }

        public static Weather SuppliedFrom(WeatherContainerDTO apiWeatherData) {
            if (apiWeatherData.Cod != 0 && apiWeatherData.Cod != 200)
                throw new ApiException("No data", HttpStatusCode.BadRequest);

            var temp =      apiWeatherData.Main?.Temp;
            var humidity =  apiWeatherData.Main?.Humidity;
            var windSpeed = apiWeatherData.Wind?.Speed;
            var weather =   apiWeatherData.Weather.Any() ? apiWeatherData.Weather[0] : null;

            return new Weather(apiWeatherData.Name != null ? apiWeatherData.Name : string.Empty,
                                           weather != null ? weather.Main : string.Empty, 
                                           weather != null ? weather.Description : string.Empty,
                                           weather != null ? weather.Icon : string.Empty,
                                              temp != null ? Convert.ToDecimal(temp.Value) : 0,
                                          humidity != null ? Convert.ToInt32(humidity.Value) : 0,
                                         windSpeed != null ? Convert.ToDecimal(windSpeed.Value) : 0,
                               Convert.ToDateTime(apiWeatherData.Dt_txt));
        }
    }
}