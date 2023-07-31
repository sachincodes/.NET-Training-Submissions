using Microsoft.AspNetCore.Mvc;
using StudentCourseWEB.Data;
using StudentCourseWEB.Models;

namespace StudentCourseWEB.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationContext context;

        public StudentController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<StudentModel> result = context.Students.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<CourseModel> courses = context.Courses.ToList();
            ViewData["Courses"] = courses;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            if(ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
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
