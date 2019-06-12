namespace WeatherApi.DTO
{
    public class WeatherContainerDTO 
    {
        public int Cod { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public MainSectionDTO Main { get; set; }
        public WeatherDTO[] Weather { get; set; }
        public WindDTO Wind {get; set;}
        public string Dt_txt { get; set; }
    }
}