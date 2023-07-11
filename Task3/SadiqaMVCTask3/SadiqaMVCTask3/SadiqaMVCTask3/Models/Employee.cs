using System.ComponentModel.DataAnnotations;

namespace SadiqaMVCTask3.Models
{
    public class Employee
    {
       
        public int EmployeeId { get; set; }
        [Display(Name ="First Name")]
        public string EmployeeFirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; } = string.Empty;

        [Display(Name = "Contact No")]
   
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; } = string.Empty;      

    }
}
