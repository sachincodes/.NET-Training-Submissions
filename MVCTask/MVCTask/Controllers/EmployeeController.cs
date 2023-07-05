using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCTask.Models;
using MVCTask.Services;

namespace MVCTask.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeServices employeeServices=new EmployeeServices();
        
        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = employeeServices.GetAll();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var model=employeeServices.GetById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
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

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = employeeServices.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeeServices.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return View();
        }

        // POST: EmployeeController/Delete/5
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
