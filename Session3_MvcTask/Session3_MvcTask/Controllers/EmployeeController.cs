using Microsoft.AspNetCore.Mvc;
using Session3_MvcTask.Models;

namespace Session3_MvcTask.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = EmployeeData.GetAllEmployees();
            return View(employees);
        }
        public IActionResult CreateEmployeeForm()
        {
                return View();
            
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            EmployeeData.SaveEmployee(employee);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
                EmployeeData.UpdateEmployee(employee);
                return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Employee employee = EmployeeData.GetEmployeeById(id);

            if (employee != null)
            {
                EmployeeData.DeleteEmployee(id);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Search(string searchText, string searchBy)
        {
            var allEmployees = EmployeeData.GetAllEmployees();
            var filteredEmployees = allEmployees;

            if (!string.IsNullOrEmpty(searchText))
            {
                if (searchBy == "name")
                {
                    filteredEmployees = filteredEmployees.Where(e => e.Name.Contains(searchText));
                }
                else if (searchBy == "department")
                {
                    filteredEmployees = filteredEmployees.Where(e => e.Department.Contains(searchText));
                }
            }
            return View("Index",filteredEmployees);
        }

    }
}
