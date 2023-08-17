using Microsoft.AspNetCore.Mvc;
using Service.Course;

namespace API.Controllers
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
        public IEnumerable<Models.Course> courses()
        {
            return _courseService.GetAllCourses();
        }

        [HttpPost]
        [Route("api/course/createcourses")]
        public IActionResult Create(Models.Course courses)
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
