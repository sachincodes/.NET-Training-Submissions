using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.Web.UI.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Name  is required")]
        public string StudentName { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Name  is required")]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public SelectList CourseList { get; set; }
    }
}