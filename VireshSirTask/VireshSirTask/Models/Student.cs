using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace VireshSirTask.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
       
    }
}
