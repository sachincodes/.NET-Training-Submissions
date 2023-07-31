using Microsoft.AspNetCore.Mvc;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;

namespace StudentCourseWEB.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDemoController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentDemoController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<StudentModel> students = _studentService.GetAllStudents();
            return View(students);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            IEnumerable<CourseModel> courses = _courseService.CourseList();
            ViewData["Courses"] = courses;
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Empty field cannot submit";
                return BadRequest(ModelState);
            }
        }
    }
}
