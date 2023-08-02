using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCourseWEB.Models
{
    public class StudentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public int StudentAge { get; set; }
        public string StudentCity { get; set; } = string.Empty;

        [ForeignKey("CourseId")]
        public virtual CourseModel? Course { get; set; }
    }
}
