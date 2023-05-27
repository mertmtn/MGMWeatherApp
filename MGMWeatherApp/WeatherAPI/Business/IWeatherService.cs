using WeatherAPI.Models.Request;

namespace WeatherAPI.Business
{
    public interface IWeatherService
    {
        Task<Root> GetAllCountry(WeatherRequest request);

        Task<Root> AddMeasuresByPlace(int placeId);
    }
}
