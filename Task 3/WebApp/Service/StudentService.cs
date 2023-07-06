using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Service
{
    public static class StudentService
    {
        private static Dictionary<int, string> student = new Dictionary<int, string>();
        private static Dictionary<int, EmployeeViewModel> employeeData = new Dictionary<int, EmployeeViewModel>();
        
        public static Dictionary<int, string> GetAllStudent()
        {
            return student;
        }
        public static void AddStudent(int key, string value)
        {
            student.Add(key, value);
        }
        public static string GetStudentByKey(int key)
        {
            if (student.ContainsKey(key))
                return student[key];

            return null;
        }
        public static bool IsExist(int key)
        {
            if(student.Count> 0 && student.ContainsKey(key))
                return true;
            return false;
        }
        public static int GetStudentCount()
        {
            return student.Count;
        }
        public static string UpdateStudentByKey(int key, string value)
        {
            if (student.ContainsKey(key))
            {
                student[key] = value;
                return student[key];
            }
            return null;
        }
        public static void DeleteStudentByKey(int key)
        {
            student.Remove(key);
        }

        #region WithModel
        public static Dictionary<int, EmployeeViewModel> GetAllEmployee()
        {
            return employeeData;
        }
        public static void AddEmployee(int key, EmployeeViewModel model)
        {
            employeeData.Add(key, model);
        }
        public static bool IsEmployeeExist(int key)
        {
            if (employeeData.Count > 0 && employeeData.ContainsKey(key))
                return true;
            return false;
        }
        public static int GetEmployeeCount()
        {
            return employeeData.Count;
        }
        public static void UpdateEmployeeByKey(int key, EmployeeViewModel model)
        {
            if (employeeData.ContainsKey(key))
                employeeData[key] = model;
        }
        public static EmployeeViewModel GetEmployeeByKey(int key)
        {
            if (employeeData.ContainsKey(key))
                return employeeData[key];

            return null;
        }
        public static void DeleteEmployeeByKey(int key)
        {
            if (employeeData.ContainsKey(key))
            {
                employeeData.Remove(key);
            }
            
        }
    }
    #endregion

}
