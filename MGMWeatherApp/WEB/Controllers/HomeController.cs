using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

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