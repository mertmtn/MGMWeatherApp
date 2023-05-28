using Business.Abstract;
using Core.Utilities.Results;
using Data.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly IFihristService _fihristService;
        private readonly IStadiumMeasuringService _stadiumMeasuringService;

        public StadiumController(IStadiumService stadiumService, IFihristService fihristService, IStadiumMeasuringService stadiumMeasuringService)
        {
            _stadiumService = stadiumService;
            _fihristService = fihristService;
            _stadiumMeasuringService = stadiumMeasuringService;
        }

        public IActionResult Index()
        {
            var stadiumList = _stadiumService.GetAllStadium().Data;
            return View(new StadiumViewModel { StadiumList = stadiumList });
        }

        public IActionResult Create()
        {
            var vm = new StadiumCreateViewModel()
            {
                MeasureDate = DateTime.Now.Date,
                WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(StadiumCreateViewModel stadiumViewModel)
        {
            try
            {
                var result = _stadiumService.Add(new Stadium
                {
                    Name = stadiumViewModel.Name ?? "",
                    CityId = stadiumViewModel.SelectedCityId
                });
                return RedirectToAction("Index", "Stadium");
            }
            catch (Exception ex)
            {
                stadiumViewModel.WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList();

                return View(stadiumViewModel);
            }
        }

        public IActionResult Edit(int? stadiumId, string dateStr)
        {
            var vm = new StadiumEditViewModel();

            var stadiumSavedDetail = new StadiumSavedDetail();

            stadiumSavedDetail.Day = DateOnly.FromDateTime(DateTime.Now);
            if (!string.IsNullOrEmpty(dateStr))
            {

                stadiumSavedDetail.Day = DateOnly.Parse(dateStr);
                stadiumSavedDetail.HourlyDetails = new List<StadiumEditEntity>();
                var weatherMeasuringResultListByStadium = _stadiumMeasuringService.GetStadiumMeasureByStadium(stadiumSavedDetail.Day, stadiumId.Value);
                foreach (var measureResult in weatherMeasuringResultListByStadium.Data)
                {
                    var stadiumEditEntity = new StadiumEditEntity
                    {
                        Hour = measureResult.Hour,
                        Temperature = measureResult.Temperature,
                        Humidity = measureResult.Humidity,
                        SelectedWeatherTypeId = measureResult.ExpectedWeatherTypeId
                    };
                    stadiumSavedDetail.HourlyDetails.Add(stadiumEditEntity);
                }
            }
            stadiumSavedDetail.Id = stadiumId.Value;
            vm.StadiumSavedDetail = stadiumSavedDetail;
            vm.WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit([FromBody] StadiumEditRequest request)
        {
            try
            {
                var stadiumMeasuringList = new List<StadiumMeasuring>();
                foreach (var item in request.Entities)
                {
                    stadiumMeasuringList.Add(new StadiumMeasuring
                    {
                        ExpectedWeatherTypeId = item.SelectedWeatherTypeId.Value,
                        Hour = item.Hour.Value,
                        Temperature = item.Temperature.Value,
                        Humidity = item.Humidity.Value,
                        MeasureDate = request.Day,
                        StadiumId = request.StadiumId.Value
                    });
                }

                var result = _stadiumMeasuringService.UpdateStadiumMeasureByDayAndStadium(stadiumMeasuringList, request.Day, request.StadiumId.Value);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = result.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException;                
            }
            return View(request);
        }

        public IActionResult Update(int? id)
        {
            var result = _stadiumService.GetById(id.Value).Data;

            var vm = new StadiumUpdateViewModel
            {
                Name = result.Name,
                CityId = result.CityId
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(StadiumUpdateViewModel vm)
        {
            try
            {
                var result = _stadiumService.Update(new Stadium
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    CityId = vm.CityId
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.Message;
                return View(vm);
            }
        }

        public JsonResult GetStadiumDetails(int? stadiumId)
        {
            try
            {
                var distictMeasureDays = _stadiumMeasuringService.GetDistinctDateByStadiumId(stadiumId.Value);

                var stadiumDetailEntryList = new List<StadiumDetailEntry>();
                var stadiumDetailEntry = new StadiumDetailEntry();

                foreach (var day in distictMeasureDays.Data)
                {
                    stadiumDetailEntry.Day = day;
                    stadiumDetailEntry.HourlyDetails = new List<StadiumEditEntity>();
                    var weatherMeasuringResultListByStadium = _stadiumMeasuringService.GetStadiumMeasureByStadium(day, stadiumId.Value);
                    foreach (var measureResult in weatherMeasuringResultListByStadium.Data)
                    {
                        var stadiumEditEntity = new StadiumEditEntity
                        {
                            Hour = measureResult.Hour,
                            Temperature = measureResult.Temperature,
                            Humidity = measureResult.Humidity,
                            SelectedWeatherTypeId = measureResult.ExpectedWeatherTypeId
                        };
                        stadiumDetailEntry.HourlyDetails.Add(stadiumEditEntity);
                    }
                    stadiumDetailEntryList.Add(stadiumDetailEntry);
                }

                var vm = new StadiumDetailViewModel();
                vm.StadiumDetailList = stadiumDetailEntryList;
                vm.WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList();

                return Json(vm);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}

