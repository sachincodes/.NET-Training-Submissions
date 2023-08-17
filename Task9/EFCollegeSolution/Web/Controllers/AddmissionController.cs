using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class AddmissionController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7178/");
        private readonly HttpClient _client;
        public AddmissionController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Student> studentViewModels = new List<Student>();
            HttpResponseMessage response = _client.GetAsync("api/student/getstudent").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                studentViewModels = JsonConvert.DeserializeObject<List<Student>>(data);
            }
            return View(studentViewModels);
        }

        public ActionResult Create()
        {
            Addmission addmissionViewModel = new Addmission();
            HttpResponseMessage response = _client.GetAsync("api/student/getcourses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var courses = JsonConvert.DeserializeObject<List<Course>>(data);
                var courseList = courses.Select(c => new Course
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName
                }).ToList();
                addmissionViewModel.Courses = courseList;
            }
            return View(addmissionViewModel);
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                HttpResponseMessage response = _client.PostAsJsonAsync<Student>("api/student/createstudent", student).Result;
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
