using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        private readonly IFihristService _fihristService;

        public StationController(IStationService stationService, IFihristService fihristService)
        {
            _stationService = stationService;
            _fihristService = fihristService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var vm = new StationCreateViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(StationCreateViewModel vm)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? stationId)
        {
            var vm = new StationUpdateViewModel()
            {
                Id = stationId ?? -1,
                Name = "İstasyon adı",
                SelectedCityId = 1,
                SelectedDistrictId = 4,
                GoogleMapsUrl = "googlemapsurl",
                ICAO = "icao",
                StationNumber = 123
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(StationUpdateViewModel vm)
        {
            var deneme = vm.SelectedDistrictId;
            return RedirectToAction("Index");
        }

        public JsonResult GetStations(int? cityId)
        {
            var stations = new List<StationUpdateViewModel>
            {
                new StationUpdateViewModel
                {
                    Id = 1,
                    Name = "İstasyon 1",
                    ICAO = "TRK",
                    District = "Kadıköy",
                    GoogleMapsUrl = "https://www.google.com/maps/search/?api=1&query=40.124,32.9992",
                    StationNumber = 12345
                },
                new StationUpdateViewModel
                {
                    Id = 2,
                    Name = "İstasyon 2",
                    ICAO = "TRK 2",
                    District = "Beşiktaş",
                    GoogleMapsUrl = "https://www.google.com/maps/search/?api=1&query=40.124,32.9992",
                    StationNumber = 4566
                }
            };

            return Json(stations);
        }
    }
}
