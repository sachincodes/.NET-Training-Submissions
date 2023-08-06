using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using Service.Interface;
using StudentEntity.Model;

namespace API.Controllers
{
    [Route("api/student/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        public StudentController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }


        [Route("getAllStudents")]
        [HttpGet]
        public IEnumerable<StudentModel> GetAllStudents()
        {
            try
            {
                return _schoolService.GetAllStudents().ToList();
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
          [HttpGet]
        public IEnumerable<CourseModel> GetAllCourses()
        {
            try
            {
                return _schoolService.GetAllCourses().ToList();
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost]
        public IActionResult AddStudent(StudentModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _schoolService.AddStudent(studentViewModel);
                    return Ok("Student added successfully.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Invalid student data.");
        }
    }
}
