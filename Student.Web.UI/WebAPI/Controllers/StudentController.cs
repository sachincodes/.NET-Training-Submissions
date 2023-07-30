using Model.Student;
using Service.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }
        [Route("api/Student/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllStudent()
        {
            try
            {
                var result = _studentService.GetAllStudent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("api/Student/Add")]
        [HttpPost]
        public IHttpActionResult AddStudent(StudentModel model)
        {
            try
            {
                var result = _studentService.AddStudent(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
