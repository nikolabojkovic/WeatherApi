namespace WeatherApi.Persistence {
    public class WeatherHistoryModel {
        public string City { get; set; }
        public decimal Temperature { get; set; }
        public int Humidity { get; set; }
    }
}