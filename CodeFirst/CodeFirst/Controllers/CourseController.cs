using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentContext _studentContext;

        public CourseController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [HttpGet]
        [Route("GetCourses")]

        public List<Course> Get()
        {
            return _studentContext.Courses.ToList();
        }

        [HttpPost]
        [Route("AddCourse")]

        public string AddCourse(Course course)
        {
            string response = string.Empty;
            _studentContext.Courses.Add(course);    
            _studentContext.SaveChanges();
            return "Course Added";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
