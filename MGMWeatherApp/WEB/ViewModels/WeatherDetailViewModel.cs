namespace WEB.ViewModels
{
    public class WeatherDetailViewModel
    {
        public List<WeatherDetailPerHourGap> WeatherDetails { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string? City { get; set; }
        public string? District { get; set; }
        public string? Region { get; set; }

        public WeatherDetailViewModel()
        {
            this.WeatherDetails = new List<WeatherDetailPerHourGap>();
        }
    }

    public class WeatherDetailPerHourGap
    {
        public string? Day { get; set; }
        public string? WeatherTypeName { get; set; }
        public double Temperature { get; set; }
        public double TemperatureFeelsLike { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
    }
}
