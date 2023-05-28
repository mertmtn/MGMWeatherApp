using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
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
            try
            {
                _stationService.Add(new Station
                {
                    Name = vm.Name ?? "",
                    CityDistrictId = vm.SelectedDistrictId,
                    GoogleMapLink = vm.GoogleMapsUrl ?? "",
                    ICAO = vm.ICAO,
                    StationNo = vm.StationNumber
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.Message;
                return View(vm);
            }
        }

        public IActionResult Update(int? stationId)
        {
            var result = _stationService.GetStationDetailById(stationId.Value).Data;

            var vm = new StationUpdateViewModel()
            {
                Id = result.Id,
                Name = result.StationName,
                SelectedCityId = result.CityId,
                SelectedDistrictId = result.DistrictId,
                GoogleMapsUrl = result.GoogleMapLink,
                ICAO = result.ICAO.ToString(),
                StationNumber = result.StationNo
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(StationUpdateViewModel vm)
        {
            try
            {
                _stationService.Update(new Station
                {
                    Id = vm.Id,
                    Name = vm.Name ?? "",
                    CityDistrictId = vm.SelectedDistrictId,
                    GoogleMapLink = vm.GoogleMapsUrl ?? "",
                    ICAO = vm.ICAO,
                    StationNo = vm.StationNumber
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.Message;
                return View(vm);
            }
        }

        public JsonResult GetStations(int? cityId)
        {
            var stations = new List<StationUpdateViewModel>();
            _stationService.GetStationListByCityId(cityId.Value).Data.ForEach(x => stations.Add(new StationUpdateViewModel
            {
                Id = x.Id,
                Name = x.StationName,
                ICAO = x.ICAO ?? "-",
                District = x.DistrictName,
                GoogleMapsUrl = x.GoogleMapLink,
                StationNumber = x.StationNo
            }));

            return Json(stations);
        }
    }
}
