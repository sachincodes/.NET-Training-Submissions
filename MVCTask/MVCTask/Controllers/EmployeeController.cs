using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using MVCTask.Services;
using System.Diagnostics;

namespace MVCTask.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeServices employeeServices = new EmployeeServices();


        public ActionResult Index()
        {
            var model = employeeServices.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = employeeServices.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Id = employeeServices.CreateEmployeeID();
                    employeeServices.Create(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var employee = employeeServices.GetById(id);
                if (employee != null)
                {
                    return View(employee);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeServices.Update(employee);
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var employee = employeeServices.GetById(id);
                if (employee != null)
                {
                    return View(employee);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                employeeServices.Delete(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
