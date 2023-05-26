using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly IStadiumMeasuringService _stadiumMeasuringService;
        private readonly IFihristService _fihristService;

        public StadiumController(IStadiumService stadiumService, IStadiumMeasuringService stadiumMeasuringService, IFihristService fihristService)
        {
            _stadiumService = stadiumService;
            _stadiumMeasuringService = stadiumMeasuringService;
            _fihristService = fihristService;
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
                Cities = _fihristService.GetAllCity().Data.Select(x => new City { Id = x.Value, Name = x.Text }).ToList(),
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
                stadiumViewModel.Cities = _fihristService.GetAllCity().Data.Select(x => new City { Id = x.Value, Name = x.Text }).ToList();
                stadiumViewModel.WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList();

                return View(stadiumViewModel);
            }
        }

        ///TODO: Modal olacaksa partial view olabilir.
        public IActionResult Edit(int id)
        {
            var result = _stadiumService.GetById(id).Data;
            var vm = new StadiumEditViewModel()
            {
                WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList()
            };
            return View(vm);
        }


        public IActionResult EntryMeasure(int id)
        {
            var vm = new StadiumMeasureEntryViewModel()
            {
                StadiumId = id,
                WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult EntryMeasure([FromBody]StadiumMeasureEntryViewModel request)
        {
            try
            {
                foreach (var item in request.Entities)
                {
                    var result = _stadiumMeasuringService.Add(new StadiumMeasuring
                    {
                        StadiumId = item.StadiumId,
                        ExpectedWeatherTypeId = item.SelectedWeatherTypeId.Value,
                        Hour = item.Hour.Value,
                        Humidity = item.Precipitation.Value,
                        Temperature = item.Temperature.Value,
                        MeasureDate = item.MeasureDate
                    });
                }
              
                return RedirectToAction("Index", "Stadium");
            }
            catch (Exception ex)
            {
                request.WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList();
                return View(request);
            }
        }

        ///TODO: Modal olacaksa redirect belirtilebilir.
        [HttpPost]
        public IActionResult Edit([FromBody] StadiumEditRequest request)
        {
            try
            {
                //var result = _stadiumService.Add(new Stadium
                //{
                //    Id = request.Id,
                //    Name = request.Name,
                //    CityId = request.CityId
                //});
                return Json(new { });
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }
        }
    }
}

