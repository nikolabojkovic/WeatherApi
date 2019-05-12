using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WeatherApi.Exceptions;

namespace WeatherApi.Domain {
    public class Forecast {

        public List<Weather> Days { get; private set; }
        public string City { get; private set; }

        private Forecast(string city, List<Weather> days) {
            Days = days;
            City = city;
        }

        public static Forecast SuppliedFrom(dynamic apiWeatherData) {
            if (apiWeatherData?.cod != null && Convert.ToInt32(apiWeatherData?.cod.Value) != 200)
                throw new ApiException("No data", HttpStatusCode.BadRequest);

            var segments = new List<Weather>();
            var days = new List<Weather>();
            var segmentsPerDay = 8;
            var city = apiWeatherData?.city?.name.Value.ToString();

            if (apiWeatherData?.list == null)
                throw new ApiException("No data", HttpStatusCode.BadRequest);

            foreach(var dynamicSegment in apiWeatherData?.list) {
                segments.Add(Weather.SuppliedFrom(dynamicSegment));
            }

            var numberOfDays = segments.Count / segmentsPerDay;

            for(int i = 0; i < numberOfDays; i++) {
                days.Add(Weather.CreateFrom(segments.Skip((i * segmentsPerDay) - 1).Take(segmentsPerDay)));
            }

            return new Forecast(city, days);
        }
    }
}