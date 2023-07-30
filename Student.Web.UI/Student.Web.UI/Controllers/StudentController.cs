using Newtonsoft.Json;
using Student.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Student.Web.UI.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            List<StudentViewModel> student = new List<StudentViewModel>();
            string apiName = "Student/GetAll";
            var data =  GetResult(apiName);
            student = JsonConvert.DeserializeObject<List<StudentViewModel>>(JsonConvert.SerializeObject(data));
            var course = GetCourse();
           foreach(var s in student)
            {
                s.CourseName = course.Where(x => x.CourseId == s.CourseId).FirstOrDefault().CourseName;
            }
            return View(student);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var model = new StudentViewModel();
            var course = GetCourse();
            model.CourseList = new SelectList(course, "CourseId", "CourseName");
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var course = GetCourse();
                model.CourseList = new SelectList(course, "CourseId", "CourseName");
                return View(model);
            }
            string apiName = "Student/Add";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var result =  PostData(json, apiName);
            if(result.StatusCode.ToString().ToUpper()=="OK"|| result.StatusCode.ToString().ToUpper() == "200")
            {
                return RedirectToAction("Index");
            }
            else{
                ViewBag.ErrorMessage = result.RequestMessage;
                var course = GetCourse();
                model.CourseList = new SelectList(course, "CourseId", "CourseName");
                return View(model);
            }
           
        }

        private List<CourseViewModel> GetCourse()
        {
            List<CourseViewModel> course = new List<CourseViewModel>();
            string apiName = "Course/GetAllCourse";
            var data = GetResult(apiName);
            course = JsonConvert.DeserializeObject<List<CourseViewModel>>(JsonConvert.SerializeObject(data));
            return course;
        }
    }
}