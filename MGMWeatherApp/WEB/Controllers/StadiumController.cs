using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        public IActionResult Index()
        {
            var stadiumList = _stadiumService.GetAllStadium().Data;
            return View(new StadiumViewModel { StadiumList = stadiumList });
        }

        ///TODO: Modal olacaksa partial view olabilir.
        public IActionResult Create()
        {
            // TODO: Burayı DB'den beslemek gerekecek.

            var vm = new StadiumCreateViewModel()
            {
                MeasureDate = DateTime.Now.Date,
                Cities = new List<City>()
                {
                    new() { Id = 1, Name = "Şehir 1" },
                    new() { Id = 2, Name = "Şehir 2" },
                    new() { Id = 3, Name = "Şehir 3" },
                    new() { Id = 4, Name = "Şehir 4" },
                    new() { Id = 5, Name = "Şehir 5" },
                    new() { Id = 6, Name = "Şehir 6" },
                },
                WeatherTypes = new List<WeatherType>()
                { 
                    new() { Id = 1, Type = "Açık", Description = "Açık" },
                    new() { Id = 2, Type = "Parçalı Bulutlu", Description = "Parçalı Bulutlu" },
                    new() { Id = 3, Type = "Az Bulutlu", Description = "Az Bulutlu" },
                    new() { Id = 4, Type = "Çok Bulutlu", Description = "Çok Bulutlu" },
                    new() { Id = 5, Type = "Pus", Description = "Pus" },
                    new() { Id = 6, Type = "Sisli", Description = "Sisli" },
                    new() { Id = 7, Type = "Duman", Description = "Duman" },
                    new() { Id = 8, Type = "Hafif Yağmurlu", Description = "Hafif Yağmurlu" },
                    new() { Id = 9, Type = "Yağmurlu", Description = "Yağmurlu" },
                    new() { Id = 10, Type = "Kuvvetli Yağmurlu", Description = "Kuvvetli Yağmurlu" },
                    new() { Id = 11, Type = "Karla Karışık Yağmurlu", Description = "Karla Karışık Yağmurlu" },
                    new() { Id = 12, Type = "Rüzgarlı", Description = "Rüzgarlı" },
                    new() { Id = 13, Type = "Hafif Kar Yağışlı", Description = "Hafif Kar Yağışlı" },
                    new() { Id = 14, Type = "Kar Yağışlı", Description = "Kar Yağışlı" },
                    new() { Id = 15, Type = "Yoğun Kar Yağışlı", Description = "Yoğun Kar Yağışlı" },
                    new() { Id = 16, Type = "Kuvvetli Gökgürültülü Sağanak Yağışlı", Description = "Kuvvetli Gökgürültülü Sağanak Yağışlı" },
                    new() { Id = 17, Type = "Yer Yer Sağanak Yağışlı", Description = "Yer Yer Sağanak Yağışlı" },
                    new() { Id = 18, Type = "Dolu", Description = "Dolu" },
                    new() { Id = 19, Type = "Gökgürültülü Sağanak Yağışlı", Description = "Gökgürültülü Sağanak Yağışlı" }
                }
            };

            return View(vm);
        }
         
        ///TODO: Modal olacaksa redirect belirtilebilir.
        [HttpPost]
        public IActionResult Create(StadiumCreateViewModel stadiumViewModel)
        {
            try
            {
                // TODO: ekrandan gelen verilerin kaydedilmesi.
                //var result = _stadiumService.Add(new Entities.Concrete.Stadium
                //{
                //    Id = stadiumViewModel.Id,
                //    Name = stadiumViewModel.StadiumDetails?.Name ?? "",
                //    CityId = stadiumViewModel.SelectedCityId
                //});
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
                throw;
            } 
        }

        ///TODO: Modal olacaksa partial view olabilir.
        public IActionResult Edit()
        {
            return View();
        }

        ///TODO: Modal olacaksa redirect belirtilebilir.
        [HttpPost]
        public IActionResult Edit(StadiumCreateOrUpdateViewModel stadiumViewModel)
        {
            try
            {
                var result = _stadiumService.Add(new Entities.Concrete.Stadium
                {
                    Id = stadiumViewModel.Id,
                    Name = stadiumViewModel.Name,
                    CityId = stadiumViewModel.CityId
                });
                return Json(result.Message);
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw;
            }
        }
    }
}

