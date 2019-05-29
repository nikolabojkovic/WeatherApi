namespace WeatherApi.DTO
{
    public class ForecastContainerDTO 
    {
        public int Cod { get; set; }
        public string Message { get; set; }
        public int Cnt { get; set; }
        public WeatherContainerDTO[] List { get; set; }
        public ForecastCityDTO City { get; set; }
        public string Test { get; set; }
    }
}