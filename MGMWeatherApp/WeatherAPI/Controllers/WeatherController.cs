using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Business;
using WeatherAPI.Models.Request;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private IWeatherService _weatherBusiness { get; set; }

        public WeatherController(IWeatherService weatherBusiness)
        {
            _weatherBusiness = weatherBusiness;
        }
        [Route("/GetWeatherForecast")]
        [HttpPost]
        public Task<Root> Get([FromBody] WeatherRequest request)
        {
            return _weatherBusiness.GetAllCountry(request);
        }

        [Route("/Add")]
        [HttpPost]
        public Task<Root> Add(int cityId)
        {
            return _weatherBusiness.AddMeasuresByPlace(cityId);
        }

        [Route("/AddByCity")]
        [HttpPost]
        public Task<string> AddMeasuresByCity(int cityId)
        {
             return _weatherBusiness.AddMeasuresByCity(cityId);

            

        }
    }
}