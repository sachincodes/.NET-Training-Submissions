using Microsoft.AspNetCore.Mvc;
using Employee.Models;
using static Employee.Static.MyDictionary;
using static Employee.Static.TodayDate;
using Employee.Static;
using Newtonsoft.Json;

namespace Employee.Controllers
{
  
    public class EmployeeController : Controller
    {
       
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmptyEmployee()
        {
            return View();
        }
        [HttpGet("allemployees")]
        public IActionResult Index()
        {
            if (MyDictionary.EmployeeData.Count == 0)
            {
                return RedirectToAction("EmptyEmployee");
            }
           List<EmployeeList> employees = new List<EmployeeList>();

           foreach(KeyValuePair<string, EmployeeList> emp in MyDictionary.EmployeeData)
           {
               employees.Add(emp.Value);
           }
            return View(employees);
        }
        
        [HttpGet]
        public IActionResult GetEmployee(string EmpId)
        {
            var Employee = MyDictionary.EmployeeData[EmpId];
          
            return View(Employee);
        }


        [HttpPost]
        public IActionResult AddEmployee(EmployeeList employee)
        {
            MyDictionary.EmployeeData.Add(employee.EmployeeId, employee);

            return RedirectToAction("AddEmployee");
        }

        [HttpGet]
        public IActionResult Delete(string EmpId)
        {
            var Employee = MyDictionary.EmployeeData[EmpId];
            return View(Employee);
        }

        [HttpPost]
        public IActionResult Remove(string EmpId)
        {
           
            MyDictionary.EmployeeData.Remove(EmpId);



            return RedirectToAction("EmptyEmployee");
        }

        [HttpGet]
        public IActionResult Edit(string EmpId)
        {
            EmployeeList employee = MyDictionary.EmployeeData[EmpId];
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeList employee )
        {
            MyDictionary.EmployeeData[employee.EmployeeId] = employee;
            
            return RedirectToAction("Index");
        }

       
    }
}
