using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public   class EmployeeViewModel
    {
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Name  is required")]
        public  string? Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The Email Address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public  string? Email { get; set; }
        public int Id { get; set; }
    }
}
