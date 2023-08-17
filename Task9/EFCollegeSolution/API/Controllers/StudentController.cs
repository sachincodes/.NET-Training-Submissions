using Microsoft.AspNetCore.Mvc;
using Service.Student;
using Models;

namespace API.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        [Route("api/student/getstudent")]
        public IEnumerable<Models.Student> students()
        {
            return _studentService.GetAllStudent();
        }
        [HttpPost]
        [Route("api/student/createstudent")]
        public IActionResult Create(Models.Student students)
        {
            try
            {
                _studentService.CreateStudent(students);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
