using Microsoft.AspNetCore.Mvc;
using StudentCourseWEB.Data;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;

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
                var result = _studentService.GetAllStudents();
                return View(result);
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
