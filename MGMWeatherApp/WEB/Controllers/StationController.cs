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

        public JsonResult GetCityList()
        {
            return Json(_fihristService.GetAllCity());
        }
    }
}
