using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Models;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7088/");
        private readonly HttpClient _client;
        public CourseController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Course> courses = new List<Course>();
            HttpResponseMessage response = _client.GetAsync("api/student/getcourses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<Course>>(data);
            }
            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course courseDTO)
        {
            try
            {
                HttpResponseMessage response = _client.PostAsJsonAsync<Course>("api/course/createcourses", courseDTO).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
