using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
