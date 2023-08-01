using EntityTaskDB;
using EntityTaskModel;
using EntityTaskService.Services.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityTaskAPI.Controllers
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
        public IEnumerable<StudentDTO> students()
        {
            return _studentService.GetAllStudent();
        }
        [HttpPost]
        [Route("api/student/createstudent")]
        public IActionResult Create(StudentDTO students)
        {
            try
            {
                _studentService.CreateStudent(students);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
