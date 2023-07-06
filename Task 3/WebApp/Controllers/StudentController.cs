using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult Index()
        {
            return View(StudentService.GetAllStudent());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( string Name)
        {
            int Id = 0;
            
            if(string.IsNullOrEmpty(Name))
            {
                ViewBag.ErrorMessage = "Name can not be empty!";
                return View();
            }
            if (!string.IsNullOrEmpty(Name))
            {
                int IdCount = StudentService.GetStudentCount();
                Id = IdCount + 1;
            }
            bool isExist= StudentService.IsExist(Id);
            if(isExist)
            {
                ViewBag.ErrorMessage = "This Id already exist!";
                return View();
            }
            StudentService.AddStudent(Id, Name);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
           var student= StudentService.GetStudentByKey(Id);
            ViewBag.Name = student;
           return View();
        }
        [HttpPost]
        public ActionResult Edit(int Id, string Name)
        {
            if (Id == 0)
            {
                ViewBag.ErrorMessage = "Id can not be zero!";
                return View();
            }
            if (string.IsNullOrEmpty(Name))
            {
                ViewBag.ErrorMessage = "Name can not be empty!";
                return View();
            }
            StudentService.UpdateStudentByKey(Id, Name);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            // Remove data from the static dictionary
            StudentService.DeleteStudentByKey(Id);

            return RedirectToAction("Index");
        }
    }

}

