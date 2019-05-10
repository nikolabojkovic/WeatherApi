using System.Collections.Generic;

namespace WeatherApi.Domain {
    public class Forcast {

        public List<Weather> Segments { get; private set; }
        public string City { get; private set; }

        private Forcast(string city, List<Weather> segments) {
            Segments = segments;
            City = city;
        }

        public static Forcast SuppliedFrom(dynamic apiWeatherData) {
            var segments = new List<Weather>();
            var city = apiWeatherData?.city?.name.Value.ToString();

            foreach(var segment in apiWeatherData.list) {
                segments.Add(Weather.SuppliedFrom(segment));
            }

            return new Forcast(city, segments);
        }
    }
}