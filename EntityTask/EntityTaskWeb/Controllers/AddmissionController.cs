using EntityTaskDB;
using EntityTaskModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace EntityTaskWeb.Controllers
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

        // GET: StudentController
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentDTO> studentViewModels = new List<StudentDTO>();
            HttpResponseMessage response = _client.GetAsync("api/student/getstudent").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                studentViewModels = JsonConvert.DeserializeObject<List<StudentDTO>>(data);
            }
            return View(studentViewModels);
        }

        public ActionResult Create()
        {
            AddmissionDTO addmissionViewModel = new AddmissionDTO();
            HttpResponseMessage response = _client.GetAsync("api/student/getcourses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var courses = JsonConvert.DeserializeObject<List<CourseDTO>>(data);
                var courseList = courses.Select(c => new CourseDTO
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName
                }).ToList();
                addmissionViewModel.courses = courseList;
            }
            return View(addmissionViewModel);
        }

        [HttpPost]
        public ActionResult Create(StudentDTO studentDTO)
        {
            try
            {
                HttpResponseMessage response =  _client.PostAsJsonAsync<StudentDTO>("api/student/createstudent", studentDTO).Result;
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
