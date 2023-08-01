using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentCourseWEB.Data;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;
using System;
using System.Text.Json;

namespace StudentCourseWEB.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7030");
                var result = client.GetAsync("api/StudentApi").Result;
                var jsonContent = result.Content.ReadAsStringAsync().Result;
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var list = System.Text.Json.JsonSerializer.Deserialize<List<StudentModel>>(jsonContent,jsonSerializerOptions );

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
            var courses = _courseService.CourseList();
            ViewBag.Courses = courses;
            ViewData["Courses"] = courses;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
            }
            else
            {
                TempData["error"] = "Empty field cannot submit";
                return View(student);
            }
            return RedirectToAction("Index");
        }
    }
}
