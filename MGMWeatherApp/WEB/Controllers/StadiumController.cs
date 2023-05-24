using Business.Abstract;
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
            return View();
        }
         
        ///TODO: Modal olacaksa redirect belirtilebilir.
        [HttpPost]
        public IActionResult Create(StadiumCreateOrUpdateViewModel stadiumViewModel)
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
            catch(Exception ex)
            {
                return Json(ex);
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

