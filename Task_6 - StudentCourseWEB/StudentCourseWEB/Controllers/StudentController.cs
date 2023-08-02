using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;


namespace StudentCourseWEB.Controllers
{
    public class StudentController : Controller
    {

        HttpClient _client = new HttpClient();

        public StudentController()
        {
            _client.BaseAddress = new Uri("https://localhost:7030");
        }
        public IActionResult Index()
        {
            try
            {
                HttpResponseMessage result = _client.GetAsync("api/StudentApi").Result;
                string jsonContent = result.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<IEnumerable<StudentViewModel>>(jsonContent);

                return View(list);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                HttpResponseMessage result = _client.GetAsync("api/CourseApi").Result;
                string jsonContent = result.Content.ReadAsStringAsync().Result;
                var courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonContent);

                //ViewBag.Courses = courses;
                ViewData["Courses"] = courses;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            try
            {
                var result = _client.PostAsJsonAsync<StudentViewModel>("api/StudentApi", student).Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                throw new Exception("Error while creating student");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
