using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<StudentViewModel> GetStudents()
        {
            return _studentService.GetAllStudents();
        }

        [HttpPost]
        public void AddStudent(StudentViewModel student)
        {
            _studentService.AddStudent(student);
        }

    }
}
