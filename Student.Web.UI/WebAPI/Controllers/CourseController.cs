using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.Course;
using Service.Course;

namespace WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;
        public CourseController()
        {
            _courseService = new CourseService();
        }
        [Route("api/Course/GetAllCourse")]
        [HttpGet]
        public IHttpActionResult GetAllCourse()
        {
            try
            {
                var result = _courseService.GetAllCourse();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("api/Course/AddCourse")]
        [HttpPost]
        public IHttpActionResult AddCourse(CourseModel model)
        {
            try
            {
                var result = _courseService.AddCourse(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
