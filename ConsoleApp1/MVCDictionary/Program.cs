using System;
using System.Collections.Generic;

namespace MVCDictionary
{
    // Model
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    // Controller
    public static class EmployeeController
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public static void Save(Employee employee)
        {
            employees[employee.Id] = employee;
        }

        public static Employee Get(int id)
        {
            if (employees.ContainsKey(id))
            {
                return employees[id];
            }
            return null;
        }

        public static void Delete(int id)
        {
            if (employees.ContainsKey(id))
            {
                employees.Remove(id);
            }
        }

        public static void Update(Employee employee)
        {
            if (employees.ContainsKey(employee.Id))
            {
                employees[employee.Id] = employee;
            }
        }
    }

    // View
    public class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee { Id = 1, Name = "Aman Singh", Department = "IT" };
            Employee employee2 = new Employee { Id = 2, Name = "Gulshan Raj", Department = "CEO" };

            EmployeeController.Save(employee1);
            EmployeeController.Save(employee2);

            // Get and display employee details
            Employee retrievedEmployee = EmployeeController.Get(1);
            if (retrievedEmployee != null)
            {
                Console.WriteLine($"Employee Details: ID={retrievedEmployee.Id}, Name={retrievedEmployee.Name}, Department={retrievedEmployee.Department}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            // Update employee details
            Employee updatedEmployee = new Employee { Id = 1, Name = "Manisha", Department = "Designer" };
            EmployeeController.Update(updatedEmployee);

            // Delete an employee
            EmployeeController.Delete(2);

            Console.ReadLine();
        }
    }
}

