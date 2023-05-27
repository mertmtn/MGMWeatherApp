using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Business;
using WeatherAPI.Models.Request;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private IWeatherService _weatherBusiness { get; set; }

        public WeatherForecastController(IWeatherService weatherBusiness)
        {
            _weatherBusiness = weatherBusiness;
        }
        [Route("/GetWeatherForecast")]
        [HttpPost]
        public Task<Root> Get([FromBody]WeatherRequest request)
        {
            return _weatherBusiness.GetAllCountry(request);
        }

        [Route("/Add")]
        [HttpPost]
        public Task<Root> Add(int cityId)
        {
            return _weatherBusiness.AddMeasuresByPlace(cityId);
        }
    }
}