using System.Collections.Generic;
using System.Linq;

namespace WeatherApi.Domain {
    public class Forecast {

        public List<Weather> Days { get; private set; }
        public string City { get; private set; }

        public string Error { get; private set; }
        public bool HasError { get; set; }

        private Forecast(string city, List<Weather> days) {
            Days = days;
            City = city;
        }

        private Forecast(string withError) {
            Error = withError;
            HasError = true;
        }

        public static Forecast WithError(string error) {
            return new Forecast(error);
        }

        public static Forecast SuppliedFrom(dynamic apiWeatherData) {
            var segments = new List<Weather>();
            var days = new List<Weather>();
            var segmentsPerDay = 8;
            var city = apiWeatherData?.city?.name.Value.ToString();

            if (apiWeatherData?.list == null)
                return Forecast.WithError("Service is not available at the moment");

            foreach(var segment in apiWeatherData?.list) {
                segments.Add(Weather.SuppliedFrom(segment));
            }

            var numberOfDays = segments.Count / segmentsPerDay;

            for(int i = 0; i < numberOfDays; i++) {
                days.Add(Weather.CreateFrom(segments.Skip((i * segmentsPerDay) - 1).Take(segmentsPerDay)));
            }

            return new Forecast(city, days);
        }
    }
}