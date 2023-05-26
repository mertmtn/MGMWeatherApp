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
        public IActionResult Edit(int? stadiumId, string dateStr)
        {
            var vm = new StadiumEditViewModel()
            {
                WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList(),
                StadiumSavedDetail = new StadiumSavedDetail() // TODO: eğer update yapılırken bu stadyum detayları varsa buraya yüklenecek. DB'den.
                {
                    Id = 2, // TODO: burası StadiumId ile aynı olmalı normalde
                    Day = DateTime.Now.AddDays(-2),
                    HourlyDetails = new()
                    {
                        new StadiumEditEntity { Hour = 08, Temperature = 12, Precipitation = 76, SelectedWeatherTypeId = 3 },
                        new StadiumEditEntity { Hour = 09, Temperature = 12, Precipitation = 71, SelectedWeatherTypeId = 3 },
                        new StadiumEditEntity { Hour = 10, Temperature = 14, Precipitation = 72, SelectedWeatherTypeId = 2 },
                        new StadiumEditEntity { Hour = 11, Temperature = 15, Precipitation = 73, SelectedWeatherTypeId = 1 },
                        new StadiumEditEntity { Hour = 12, Temperature = 16, Precipitation = 74, SelectedWeatherTypeId = 3 },
                        new StadiumEditEntity { Hour = 13, Temperature = 17, Precipitation = 75, SelectedWeatherTypeId = 5 },
                        new StadiumEditEntity { Hour = 14, Temperature = 18, Precipitation = 76, SelectedWeatherTypeId = 6 },
                        new StadiumEditEntity { Hour = 15, Temperature = 19, Precipitation = 77, SelectedWeatherTypeId = 3 },
                        new StadiumEditEntity { Hour = 16, Temperature = 16, Precipitation = 78, SelectedWeatherTypeId = 3 }
                    },
                }
            };
            return View(vm);
        }

        ///TODO: Modal olacaksa redirect belirtilebilir.
        [HttpPost]
        public IActionResult Edit([FromBody] StadiumEditRequest request)
        {
            try
            {
                // request.Entities içindeki itemların Id bilgisi varsa mevcutta olan bir detay bilgisi kaydediliyordur.
                // Id null ise yeni eklenecektir.
                // listenen silinen veriler de göz önüne alınmalı, stadyum ölçümü olan ve request içinde
                // bulunmayan kayıtlar DB'de de silinmelidir.
                // day bilgisi ile bu sorguları yapabilirsin. Day bilgisinin değiştirilmesine izin verilmeyecek front-end'de.

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

        public JsonResult GetStadiumDetails(int? stadiumId)
        {
            try
            {
                var resp = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList();

                var vm = new StadiumDetailViewModel
                {
                    WeatherTypes = _fihristService.GetAllWeatherType().Data.Select(x => new WeatherType { Id = x.Value, Type = x.Text }).ToList(),
                    StadiumDetailList = new()
                    {
                        new StadiumDetailEntry
                        {
                            Day = DateTime.Now.AddDays(0),
                            HourlyDetails = new()
                            {
                                new StadiumEditEntity { Hour = 08, Temperature = 12, Precipitation = 76, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 09, Temperature = 12, Precipitation = 71, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 10, Temperature = 14, Precipitation = 72, SelectedWeatherTypeId = 2 },
                                new StadiumEditEntity { Hour = 11, Temperature = 15, Precipitation = 73, SelectedWeatherTypeId = 1 },
                                new StadiumEditEntity { Hour = 12, Temperature = 16, Precipitation = 74, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 13, Temperature = 17, Precipitation = 75, SelectedWeatherTypeId = 5 },
                                new StadiumEditEntity { Hour = 14, Temperature = 18, Precipitation = 76, SelectedWeatherTypeId = 6 },
                                new StadiumEditEntity { Hour = 15, Temperature = 19, Precipitation = 77, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 16, Temperature = 16, Precipitation = 78, SelectedWeatherTypeId = 3 },
                            }
                        },
                        new StadiumDetailEntry
                        {
                            Day = DateTime.Now.AddDays(-1),
                            HourlyDetails = new()
                            {
                                new StadiumEditEntity { Hour = 08, Temperature = 22, Precipitation = 66, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 09, Temperature = 22, Precipitation = 61, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 10, Temperature = 24, Precipitation = 62, SelectedWeatherTypeId = 2 },
                                new StadiumEditEntity { Hour = 11, Temperature = 25, Precipitation = 63, SelectedWeatherTypeId = 1 },
                                new StadiumEditEntity { Hour = 12, Temperature = 26, Precipitation = 64, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 13, Temperature = 27, Precipitation = 65, SelectedWeatherTypeId = 5 },
                                new StadiumEditEntity { Hour = 14, Temperature = 28, Precipitation = 66, SelectedWeatherTypeId = 6 },
                                new StadiumEditEntity { Hour = 15, Temperature = 29, Precipitation = 67, SelectedWeatherTypeId = 3 },
                                new StadiumEditEntity { Hour = 16, Temperature = 26, Precipitation = 68, SelectedWeatherTypeId = 3 },
                            }
                        }
                    }
                };

                return Json(vm);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}

