namespace SadiqaMVCTask3.Models
{
    public static class EmployeeDetails
    {

        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public static IEnumerable<Employee> GetAllEmployees()
        {
            return employees.Values;
        }

        public static Employee GetEmployeeById(int empId)
        {
            if (employees.ContainsKey(empId))
            {
                return employees[empId];
            }

            return null;
        }

        public static void SaveEmployee(Employee employee)
        {
            if (!employees.ContainsKey(employee.EmployeeId))
            {
                if (employees.Count > 0)
                {
                    employee.EmployeeId = employees.Max(a => a.Key) + 1;
                }
                else
                {
                    employee.EmployeeId = 1;
                }
                employees.Add(employee.EmployeeId, employee);
            }
        }

        public static void UpdateEmployee(Employee employee)
        {
            if (employees.ContainsKey(employee.EmployeeId))
            {
                employees[employee.EmployeeId] = employee;                
                
            }
            
        }

        public static void DeleteEmployee(int empId)
        {
            if (employees.ContainsKey(empId))
            {
                employees.Remove(empId);
            }
        }
    }
}
