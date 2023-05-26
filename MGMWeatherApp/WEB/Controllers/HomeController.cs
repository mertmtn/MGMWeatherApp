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
            var vm = new HomeIndexViewModel()
            {
                Cities = new()
                {
                    new City()
                    {
                        Id = 1,
                        Name = "Şehir 1",
                        Districts = new()
                        {
                            new District()
                            {
                                Id = 1,
                                Name = "Şehir 1 ilçe 1"
                            },
                            new District()
                            {
                                Id = 2,
                                Name = "Şehir 1 ilçe 2"
                            }
                        }
                    },
                    new City()
                    {
                        Id = 2,
                        Name = "Şehir 2",
                        Districts = new()
                        {
                            new District()
                            {
                                Id = 3,
                                Name = "Şehir 2 ilçe 1"
                            },
                            new District()
                            {
                                Id = 4,
                                Name = "Şehir 2 ilçe 2"
                            }
                        }
                    }
                }
            };

            return View(vm);
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
                        HourGap = "13:00-14:00",
                        WeatherTypeName = "Güneşli",
                        Temperature = 13,
                        TemperatureFeelsLike = 14,
                        Humidity = 86,
                        WindDirection = "Kuzey Batı",
                        AverageWindSpeed = 6,
                        MaxWindSpeed = 12
                    },
                    new WeatherDetailPerHourGap()
                    {
                        Day = "Çarşamba",
                        HourGap = "14:00-16:00",
                        WeatherTypeName = "Güneşli",
                        Temperature = 17,
                        TemperatureFeelsLike = 18,
                        Humidity = 82,
                        WindDirection = "Kuzey",
                        AverageWindSpeed = 8,
                        MaxWindSpeed = 11
                    }
                }
            };

            return Json(vm);
        }
    }
}