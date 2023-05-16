namespace WeatherAPI.Models.Options
{
    
    public class OpenWeatherMapApiInfo
    {
        public OpenWeatherMapApiInfo()
        {
            OpenWeatherMapApiLink = new OpenWeatherMapApiLink();
        }
        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }
        public string HttpClientName { get; set; }
        public OpenWeatherMapApiLink OpenWeatherMapApiLink { get; set; }
    }

    public class OpenWeatherMapApiLink
    {
        public string OneCall { get; set; } 
    }
}
