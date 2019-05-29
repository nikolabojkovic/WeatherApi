using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WeatherApi.DTO;
using WeatherApi.Exceptions;

namespace WeatherApi.Domain {
    public class Forecast {

        public List<Weather> Days { get; private set; }
        public string City { get; private set; }

        private Forecast(string city, List<Weather> days) {
            Days = days;
            City = city;
        }

        public static Forecast SuppliedFrom(ForecastContainerDTO apiForecastData) {
            if (apiForecastData.Cod != 200)
                throw new ApiException("No data", HttpStatusCode.BadRequest);

            if (!apiForecastData.List.Any())
                throw new ApiException("No data", HttpStatusCode.BadRequest);

            var forecastSegments = new List<Weather>();
            var days = new List<Weather>();
            var city = apiForecastData.City?.Name;            

            foreach(var apiDataSegment in apiForecastData.List) {
                forecastSegments.Add(Weather.SuppliedFrom(apiDataSegment));
            }          

            foreach(var group in forecastSegments.GroupBy(x => x.AtDateTime.ToShortDateString())) {
                days.Add(Weather.CreateFrom(forecastSegments.Where(x => x.AtDateTime.ToShortDateString() == group.Key)));
            }

            return new Forecast(city, days);
        }
    }
}