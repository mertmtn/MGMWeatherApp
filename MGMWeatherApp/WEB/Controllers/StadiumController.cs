using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly IFihristService _fihristService;

        public StadiumController(IStadiumService stadiumService, IFihristService fihristService)
        {
            _stadiumService = stadiumService;
            _fihristService = fihristService;
        }

        public IActionResult Index()
        {
            var stadiumList = _stadiumService.GetAllStadium().Data;
            return View(new StadiumViewModel { StadiumList = stadiumList });
        }

        ///TODO: Modal olacaksa partial view olabilir.
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

        ///TODO: Modal olacaksa redirect belirtilebilir.
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
        public IActionResult Edit()
        {
            var vm = new StadiumEditViewModel()
            {
                WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList()
            };
            return View(vm);
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

