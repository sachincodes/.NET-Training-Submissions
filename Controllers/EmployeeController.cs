using CrudLibrary.Models;
using CrudLibrary.StaticClass;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudLibrary.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (KeyValuePair<int, EmployeeModel> emp in EmployeeDictionary.EmployeeData)
            {
                employees.Add(emp.Value);
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AlreadyExists()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(EmployeeModel emp)
        {
            if(EmployeeDictionary.EmployeeData.ContainsKey(emp.EmpId))
            {
                return RedirectToAction("AlreadyExists");
            }
            EmployeeDictionary.EmployeeData.Add(emp.EmpId, emp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int EmpId)
        {
            EmployeeModel emp = EmployeeDictionary.EmployeeData[EmpId];
            return View(emp);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel emp)
        {
            EmployeeDictionary.EmployeeData[emp.EmpId] = emp;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int EmpId)
        {
            return View(EmployeeDictionary.EmployeeData[EmpId]);
        }

        [HttpGet]
        public IActionResult Delete(int EmpId)
        {
            return View(EmployeeDictionary.EmployeeData[EmpId]);
        }

        [HttpPost]
        public ActionResult RemoveEmployee(int EmpId)
        {
            EmployeeDictionary.EmployeeData.Remove(EmpId);
            return RedirectToAction("Index");
        }
    }
}
