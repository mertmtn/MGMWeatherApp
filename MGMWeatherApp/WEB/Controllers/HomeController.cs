using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityDistrictMeasuringService _cityDistrictMeasuringService;
        private readonly ICoordinateService _coordinateService;
        private readonly IFihristService _fihristService;

        public HomeController(ICityDistrictMeasuringService cityDistrictMeasuringService, ICoordinateService coordinateService, IFihristService fihristService)
        {
            _cityDistrictMeasuringService = cityDistrictMeasuringService;
            _coordinateService = coordinateService;
            _fihristService = fihristService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetWeatherByCityAndDistrict(int? cityId, int? districtId)
        {
            var weatherMeasuringResultList = _cityDistrictMeasuringService.GetMeasureResultByPlaceId(districtId ?? 82);
            var coordinates = _coordinateService.GetCoordinateByPlaceId(districtId ?? 82);
            var cityInfo = _fihristService.GetPlaceInfoByDistrictId(districtId ?? 82);
            var vm = new WeatherDetailViewModel()
            {
                Latitude = coordinates.Data.Latitude,
                Longitude = coordinates.Data.Longitude,
                City = cityInfo.Data.City.Name,
                District = cityInfo.Data.Name,
                Region = cityInfo.Data.City.Region.Name
            };

            foreach (var measureResult in weatherMeasuringResultList.Data)
            {
                vm.WeatherDetails.Add(new WeatherDetailPerHourGap
                {
                    Day = measureResult.MeasureDate.ToString("dd.MM.yyyy"),
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