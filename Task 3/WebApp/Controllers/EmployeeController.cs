using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View(StudentService.GetAllEmployee());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            if(!ModelState.IsValid) { 
                return View(model);
            }
            int Id = 0;
            if (string.IsNullOrEmpty(model.Name))
            {
                ViewBag.ErrorMessage = "Name can not be empty!";
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                ViewBag.ErrorMessage = "Email can not be empty!";
                return View(model);
            }
            if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Email))
            {
                int IdCount = StudentService.GetEmployeeCount();
                Id = IdCount + 1;
            }
            StudentService.AddEmployee(Id, model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model=new EmployeeViewModel();
            var employee = StudentService.GetEmployeeByKey(Id);
            model.Name = employee.Name;
            model.Email = employee.Email;
            model.Id = Id;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Id == 0)
            {
                ViewBag.ErrorMessage = "Id can not be zero!";
                return View(model);
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                ViewBag.ErrorMessage = "Name can not be empty!";
                return View(model);
            }
            StudentService.UpdateEmployeeByKey(model.Id,model);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            // Remove data from the static dictionary
            StudentService.DeleteEmployeeByKey(Id);

            return RedirectToAction("Index");
        }
    }
}

