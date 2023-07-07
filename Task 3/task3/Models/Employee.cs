using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task3.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the employee's name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the employee's department.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please enter the employee's salary.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public double Salary { get; set; }
    }
}