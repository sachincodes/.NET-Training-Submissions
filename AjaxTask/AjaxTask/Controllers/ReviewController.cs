using AjexTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace AjexTask.Controllers
{
    public class ReviewController : Controller
    {
        ReviewService reviewService = new ReviewService();
        public IActionResult Index()
        {
            var data = reviewService.Review(0, 10);
            return View(data);
        }
        public IActionResult AddMore(int skipItem, int takeItem=5)
        {
            var data = reviewService.Review(skipItem, takeItem);
            return Json(data);
        }
    }
}
