using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityDistrictMeasuringService _cityDistrictMeasuringService;
        private readonly ICoordinateService _coordinateService;
        public HomeController(ICityDistrictMeasuringService cityDistrictMeasuringService, ICoordinateService coordinateService)
        {
            _cityDistrictMeasuringService = cityDistrictMeasuringService;
            _coordinateService = coordinateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetWeatherByCityAndDistrict(int? cityId, int? districtId)
        {
            var weatherMeasuringResultList = _cityDistrictMeasuringService.GetMeasureResultByPlaceId(districtId ?? 82);
            var coordinates = _coordinateService.GetCoordinateByPlaceId(districtId ?? 82);
           
            var vm = new WeatherDetailViewModel()
            {
                Latitude = coordinates.Data.Latitude,
                Longitude = coordinates.Data.Longitude,
                City="İstanbul",
                District="Fatih",
                Region="Marmara Bölgesi"
            };

            foreach (var measureResult in weatherMeasuringResultList.Data)
            {
                vm.WeatherDetails.Add(new WeatherDetailPerHourGap
                {
                    Day = measureResult.MeasureDate.ToShortDateString(),
                    WeatherTypeName = measureResult.WeatherType.Type,
                    Temperature = measureResult.Temperature,
                    TemperatureFeelsLike = measureResult.FeelsTemperature,
                    Humidity = measureResult.Humidity,
                    WindSpeed = measureResult.WindSpeed,
                    Pressure = measureResult.Pressure
                });
            }

            return Json(vm);
        }
    }
}