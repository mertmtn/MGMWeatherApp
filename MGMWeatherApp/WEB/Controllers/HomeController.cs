using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;
using WEB.ViewModels;
using static System.Net.WebRequestMethods;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetWeatherByCityAndDistrict(int? cityId, int? districtId)
        {
            var vm = new WeatherDetailViewModel()
            {
                Latitude = 39.9727,
                Longitude = 32.8637,
                WeatherDetails = new()
                {
                    new WeatherDetailPerHourGap()
                    {
                        Day = "Çarşamba",
                        WeatherTypeName = "Güneşli",
                        Temperature = 13,
                        TemperatureFeelsLike = 14,
                        Humidity = 86,
                        WindSpeed = 12,
                        Pressure = 32,
                    },
                    new WeatherDetailPerHourGap()
                    {
                        Day = "Perşembe",
                        WeatherTypeName = "Güneşli",
                        Temperature = 17,
                        TemperatureFeelsLike = 18,
                        Humidity = 82,
                        WindSpeed = 11,
                        Pressure = 32,
                    }
                }
            };

            return Json(vm);
        }
    }
}