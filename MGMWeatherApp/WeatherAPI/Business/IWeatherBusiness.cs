using WeatherAPI.Models.Request;

namespace WeatherAPI.Business
{
    public interface IWeatherBusiness
    {
        Task<Root> GetAllCountry(WeatherRequest request);
    }
}
