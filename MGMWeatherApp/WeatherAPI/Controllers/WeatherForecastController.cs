using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Business;
using WeatherAPI.Models.Request;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private IWeatherBusiness _weatherBusiness { get; set; }

        public WeatherForecastController(IWeatherBusiness weatherBusiness)
        {
            _weatherBusiness = weatherBusiness;
        }   

        [HttpPost(Name = "GetWeatherForecast")]
        public Task<Root> Get([FromBody]WeatherRequest request)
        {
            return _weatherBusiness.GetAllCountry(request);
        }
    }
}