using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseWEB.Models;
using StudentCourseWEB.Services;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseAPIController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IEnumerable<CourseModel> GetCourses()
        {
            return _courseService.CourseList();
        }

        [HttpPost]
        public void AddCourse(CourseViewModel course)
        {
            _courseService.AddCourse(course);
        }
    }
}
