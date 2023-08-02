using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentCourseWEB.Models;
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
            try
            {
                HttpResponseMessage result = _client.GetAsync("api/CourseApi").Result;
                string jsonContent = result.Content.ReadAsStringAsync().Result;
                var courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonContent);

                return View(courses);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseViewModel course) 
        {
            try
            {
                var result = _client.PostAsJsonAsync<CourseViewModel>("api/CourseApi", course).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                throw new Exception("Error occured while adding course");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
