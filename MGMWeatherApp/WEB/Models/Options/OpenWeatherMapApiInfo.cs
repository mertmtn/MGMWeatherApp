namespace WEB.Models.Options
{
    
    public class OpenWeatherMapApiInfo
    {
        public OpenWeatherMapApiInfo()
        {
            OpenWeatherMapApiLink = new OpenWeatherMapApiLink();
        }
        public string BaseUrl { get; set; }
        public string HttpClientName { get; set; }
        public OpenWeatherMapApiLink OpenWeatherMapApiLink { get; set; }
    }

    public class OpenWeatherMapApiLink
    {
        public string AvailableCountries { get; set; }
        public string PublicHolidays { get; set; }
    }
}
