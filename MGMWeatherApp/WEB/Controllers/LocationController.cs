using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class LocationController : Controller
    {
        private readonly IFihristService _fihristService;

        public LocationController(IFihristService fihristService)
        {
            _fihristService = fihristService;
        }

        public JsonResult GetCityList()
        {
            var cities = _fihristService.GetAllCity().Data.Select(x => new City { Id = x.Value, Name = x.Text}); 
            return Json(cities); 
        }

        public JsonResult GetDistrictList(int cityId)
        { 
            var districts = _fihristService.GetAllDistrict(cityId).Data.Select(x => new District { Id = x.Value, Name = x.Text });
            return Json(districts);
        }
    }
}
