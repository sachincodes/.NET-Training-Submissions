using EntityTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace EntityTaskWeb.Controllers
{
    public class CourseController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7178/");
        private readonly HttpClient _client;
        public CourseController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            HttpResponseMessage response = _client.GetAsync("api/student/getcourses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<CourseDTO>>(data);
            }
            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseDTO courseDTO)
        {
            try
            {
                HttpResponseMessage response = _client.PostAsJsonAsync<CourseDTO>("api/course/createcourses", courseDTO).Result;
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