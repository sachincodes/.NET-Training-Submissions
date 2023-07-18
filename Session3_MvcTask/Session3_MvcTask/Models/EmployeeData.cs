using System;
using System.Collections.Generic;
using System.Linq;

namespace Session3_MvcTask.Models
{
    public class EmployeeData
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public static IEnumerable<Employee> GetAllEmployees()
        {
            return employees.Values;
        }

        public static Employee GetEmployeeById(int id)
        {
            if (employees.ContainsKey(id) && (id != 0))
            {
                return employees[id];
            }

            throw new ArgumentException("Employee not found");
        }

        public static void SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                if (employees.Count > 0)
                {
                    int maxId = employees.Keys.Max();
                    int newId = GenerateNewId(maxId);
                    employee.Id = newId;
                }
                else
                {
                    employee.Id = 1; // Assign the ID "1" if there are no existing employees
                }
            }

            if (!employees.ContainsKey(employee.Id))
            {
                employees.Add(employee.Id, employee);
            }
        }

        public static void UpdateEmployee(Employee employee)
        {
            if (employees.ContainsKey(employee.Id))
            {
                employees[employee.Id] = employee;
            }
        }

        public static void DeleteEmployee(int id)
        {
            if (employees.ContainsKey(id))
            {
                employees.Remove(id);
            }
        }

        private static int GenerateNewId(int maxId)
        {
            // Logic to generate a new ID based on the current maximum ID
            int newIntId = maxId + 1;
            return newIntId;
        }
    }

    public class Employee
    {
        public int Id { get; set; }= 0;
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime DateOfJoining { get; set; }
        public string ContactNumber { get; set; } = string.Empty ;
    }
}




//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Newtonsoft.Json;

//namespace Session3_MvcTask.Models
//{
//    public class EmployeeData
//    {
//        private static Dictionary<string, string> employees = new Dictionary<string, string>();

//        public static IEnumerable<Employee> GetAllEmployees()
//        {
//            return employees
//                .Select(e => JsonConvert.DeserializeObject<Employee>(e.Value))
//                .Where(e => e != null)!; // Filter out null values and use the null-forgiving operator (!)
//        }

//        public static Employee GetEmployeeById(string id)
//        {
//            try
//            {
//                if (employees.ContainsKey(id))
//                {
//                    return JsonConvert.DeserializeObject<Employee>(employees[id])!;
//                }
//            }
//            catch (Exception ex)
//            {
//                // Handle any specific exception types if needed
//                Console.WriteLine("Error deserializing employee: " + ex.Message);
//            }

//            throw new ArgumentException("Employee not found");
//        }


//        public static void SaveEmployee(Employee employee)
//        {
//            if (string.IsNullOrEmpty(employee.Id))
//            {
//                if (employees.Count > 0)
//                {
//                    string maxId = employees.Keys.Max()!;
//                    string newId = GenerateNewId(maxId);
//                    employee.Id = newId;
//                }
//                else
//                {
//                    employee.Id = "1"; // Assign the ID "1" if there are no existing employees
//                }
//            }

//            if (!employees.ContainsKey(employee.Id))
//            {
//                string json = JsonConvert.SerializeObject(employee);
//                employees.Add(employee.Id, json);
//            }
//        }

//        public static void UpdateEmployee(Employee employee)
//        {
//            if (employees.ContainsKey(employee.Id))
//            {
//                string json = JsonConvert.SerializeObject(employee);
//                employees[employee.Id] = json;
//            }
//        }

//        public static void DeleteEmployee(string id)
//        {
//            if (employees.ContainsKey(id))
//            {
//                employees.Remove(id);
//            }
//        }

//        private static string GenerateNewId(string maxId)
//        {
//            // Logic to generate a new ID based on the current maximum ID
//            // For example, you can increment the integer representation of the ID or use any other custom logic
//            // This is just a simple example
//            int maxIntId = int.Parse(maxId);
//            int newIntId = maxIntId + 1;
//            return newIntId.ToString();
//        }
//    }

//    public class Employee
//    {
//        public string Id { get; set; }
//        public string Name { get; set; } = string.Empty;
//        public string Department { get; set; } = string.Empty;
//    }
//}
