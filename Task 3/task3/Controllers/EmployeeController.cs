using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task3.Models;

namespace task3.Controllers
{
    public class EmployeeController : Controller
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        private static int nextId = 1;

        public ActionResult Index()
        {
            return View(employees.Values);
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
                    employee.Id = nextId;
                    employees[nextId] = employee;
                    nextId++;
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
                if (employees.ContainsKey(id))
                {
                    return View(employees[id]);
                }

                return RedirectToAction("Index");
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
                    if (employees.ContainsKey(employee.Id))
                    {
                        employees[employee.Id] = employee;
                    }
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
                if (employees.ContainsKey(id))
                {
                    return View(employees[id]);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (employees.ContainsKey(id))
                {
                    employees.Remove(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}