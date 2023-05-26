namespace WEB.ViewModels
{
    public class WeatherDetailViewModel
    {
        public List<WeatherDetailPerHourGap> WeatherDetails { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public WeatherDetailViewModel()
        {
            this.WeatherDetails = new List<WeatherDetailPerHourGap>();
        }
    }

    public class WeatherDetailPerHourGap
    {
        public string? Day { get; set; }
        public string? WeatherTypeName { get; set; }
        public int Temperature { get; set; }
        public int TemperatureFeelsLike { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        public int Pressure { get; set; }
    }
}
