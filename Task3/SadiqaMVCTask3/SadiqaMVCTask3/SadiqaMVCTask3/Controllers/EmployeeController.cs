using Microsoft.AspNetCore.Mvc;
using SadiqaMVCTask3.Models;
using PageList;

namespace SadiqaMVCTask3.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(int? page)
        {
            var employees = EmployeeDetails.GetAllEmployees(); 
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = EmployeeDetails.GetEmployeeById(id);

            if (employee == null)
            {
                return BadRequest();
            }

            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDetails.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = EmployeeDetails.GetEmployeeById(id);

            if (employee == null)
            {
                return BadRequest();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeDetails.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = EmployeeDetails.GetEmployeeById(id);

            if (employee == null)
            {
                return BadRequest();
            }

            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetails.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
