using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class OrderNow : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
