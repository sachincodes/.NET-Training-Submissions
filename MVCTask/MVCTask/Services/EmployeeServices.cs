using MVCTask.Models;

namespace MVCTask.Services
{
    public class EmployeeServices
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public void Create(Employee employee)
        {
            employees.Add(employee.Id, employee);
        }

        public void Delete(Employee employee)
        {
            employees.Remove(employee.Id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees.Values;
        }

        public Employee GetById(int id)
        {
            return employees[id];
        }

        public void Update(Employee employee)
        {
            employees[employee.Id] = employee;
        }
    }
}
