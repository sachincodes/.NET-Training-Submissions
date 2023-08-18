using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
    }
}
