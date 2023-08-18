using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
