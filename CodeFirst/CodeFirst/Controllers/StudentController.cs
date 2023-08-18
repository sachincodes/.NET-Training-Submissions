using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _studentContext;
        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [HttpGet]
        [Route("GetStudents")]

        public  List<Student> GetStudents()
        {
            var list = _studentContext.Students.ToList();
            return list;
        }

        [HttpGet]
        [Route("GetStudent")]

        public Student GetStudent(int id)
        {
            return _studentContext.Students.Where( x => x.StudentId == id).FirstOrDefault();
        }
        [HttpGet]
        [Route("AddStudents")]
        public IActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        [Route("AddStudents")]
        public string AddStudent(Student student)
        {
            string response = string.Empty;
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
            return "Student Added";
        }
    }
}
