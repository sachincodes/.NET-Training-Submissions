using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using StudentEntity.Model;
using Web.Models;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _baseUrl;
        private readonly IConfiguration _configuration;
        private readonly APIRequest _apiRequest;


        public StudentController(ILogger<HomeController> logger, IConfiguration configuration, APIRequest apiRequest)
        {
            _logger = logger;
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("BaseURL");
            _apiRequest = apiRequest;
        }

        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            try
            {
                List<StudentModel> studentViewModels = new List<StudentModel>();
                HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/student/getAllStudents").Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    if (data != null)
                    {
                        studentViewModels = JsonConvert.DeserializeObject<List<StudentModel>>(data) ?? new List<StudentModel>();
                    }
                }
                return View(studentViewModels);

            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public IActionResult GetAllCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            HttpResponseMessage response = client.GetAsync("api/student/getcourses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<CourseModel>>(data) ?? new List<CourseModel>();
            }
            return View(courses);
        }

        public IActionResult StudentForm()
        {
            StudentDetail studentDetail = new StudentDetail();
            HttpResponseMessage response = client.GetAsync($"{_baseUrl}/api/student/getAllCourses").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var courses = JsonConvert.DeserializeObject<List<CourseModel>>(data);
                if(courses != null)
                {
                    var courseList = courses.Select(c => new CourseModel
                    {
                        CourseId = c.CourseId,
                        CourseName = c.CourseName
                    }).ToList();
                    studentDetail.Course = courseList;

                }
            }
            return View(studentDetail);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel student)
        {
            try
            {
                HttpResponseMessage response = _apiRequest._client.PostAsJsonAsync<StudentModel>($"{_baseUrl}/api/student/addStudent",student).Result;
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