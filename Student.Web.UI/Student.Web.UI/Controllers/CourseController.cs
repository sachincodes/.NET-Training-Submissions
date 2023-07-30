using Model.Course;
using Newtonsoft.Json;
using Student.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Student.Web.UI.Controllers
{
    public class CourseController : BaseController
    {
        
        // GET: Course
        [HttpGet]
        public ActionResult Index()
        {
            List<CourseViewModel> course = new List<CourseViewModel>();
            string apiName = "Course/GetAllCourse";
            var data = GetResult(apiName);
            course  = JsonConvert.DeserializeObject<List<CourseViewModel>>(JsonConvert.SerializeObject(data));
            return View(course);
        }

        
    }
}
