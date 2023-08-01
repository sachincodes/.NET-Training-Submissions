using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;

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
        public IEnumerable<StudentModel> GetStudents()
        {
            return _studentService.GetAllStudents();
        }
        

    }
}
