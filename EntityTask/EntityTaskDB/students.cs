using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityTaskDB
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public virtual Courses? courses { get; set; }

    }
}