using Microsoft.AspNetCore.Mvc;
using shivamTask.Models.Domain;
using shivamTask.Models.ViewModel;
using shivamTask.MyDictionary;
namespace shivamTask.Controllers
{
    public class EmployeeController : Controller
      { 

         
        public IActionResult Add()
        {         
             

            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployee newemp)
        { 

              Employee employee = new Employee();
            employee.Name = newemp.Name;    
            employee.Email = newemp.Email;
            employee.AdharNo = newemp.AdharNo;
            employee.Role = newemp.Role;
            employee.Id=Guid.NewGuid();
             MyDictionary.MyDictionary.mydict.Add(employee.Id, employee);
            Console.WriteLine(MyDictionary.MyDictionary.mydict.Count);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditEmployee(Guid Id)
        {



            Employee editemp = MyDictionary.MyDictionary.mydict[Id];
            Console.WriteLine(editemp);
            return View(editemp);

        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee emp)
        {
           
            MyDictionary.MyDictionary.mydict[emp.Id].Name = emp.Name; 
            MyDictionary.MyDictionary.mydict[emp.Id].Role = emp.Role;
            MyDictionary.MyDictionary.mydict[emp.Id].AdharNo = emp.AdharNo;
            MyDictionary.MyDictionary.mydict[emp.Id].Email = emp.Email;
            return RedirectToAction("Index" ,"Home");   

        }

     
        public IActionResult  DeleteEmployee (Guid id) {
           
            
            
            MyDictionary.MyDictionary.mydict.Remove(id);
            return RedirectToAction("Index", "Home"); 
        
        }   



    }
}
