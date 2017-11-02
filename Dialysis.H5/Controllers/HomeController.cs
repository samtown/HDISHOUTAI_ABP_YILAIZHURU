using Microsoft.AspNetCore.Mvc;

namespace Dialysis.H5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}
