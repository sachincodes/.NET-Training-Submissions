using EntityTaskDB;
using EntityTaskModel;
using EntityTaskService.Services.Course;
using EntityTaskService.Services.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityTaskAPI.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("api/student/getcourses")]
        public IEnumerable<CourseDTO> courses()
        {
            return _courseService.GetAllCourses();
        }

        [HttpPost]
        [Route("api/course/createcourses")]
        public IActionResult Create(CourseDTO courses)
        {
            try
            {
                _courseService.Create(courses);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
