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
            var cities = new List<City>()
            {
                new City()
                {
                    Id = 0,
                    Name = "İl 1"
                },
                new City()
                {
                    Id = 1,
                    Name = "İl 2"
                },
                new City()
                {
                    Id = 2,
                    Name = "İl 3"
                },
            };

            return Json(cities);
            //return Json(_fihristService.GetAllCity());
        }

        public JsonResult GetDistrictList(int cityId)
        {
            var districts = new List<District>();

            if (cityId == 0)
            {
                districts = new List<District>()
                {
                    new District(){ Id = 1, Name = "İlçe 1" },
                    new District(){ Id = 2, Name = "İlçe 2" },
                };
            }
            else if(cityId == 1)
            {
                districts = new List<District>()
                {
                    new District(){ Id = 3, Name = "İlçe 3" },
                    new District(){ Id = 4, Name = "İlçe 4" },
                };
            }
            else
            {
                districts = new List<District>()
                {
                    new District(){ Id = 5, Name = "İlçe 5" },
                    new District(){ Id = 6, Name = "İlçe 6" },
                };
            }

            return Json(districts);
        }
    }
}
