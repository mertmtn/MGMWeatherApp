using Microsoft.AspNetCore.Mvc; 

namespace WEB.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}