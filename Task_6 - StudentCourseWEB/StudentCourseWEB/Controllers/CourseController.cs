using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Controllers
{
    public class CourseController : Controller
    {

        HttpClient _client = new HttpClient();
        public CourseController()
        {
            _client.BaseAddress = new Uri("https://localhost:7030");
        }

        public IActionResult Index()
        {
            HttpResponseMessage result = _client.GetAsync("api/CourseApi").Result;
            string jsonContent = result.Content.ReadAsStringAsync().Result;
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonContent);

            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel course) 
        {
            var result = _client.PostAsJsonAsync<CourseViewModel>("api/CourseApi",course).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            TempData["error"] = "Error";
            return View("Index");
        }
    }
}
