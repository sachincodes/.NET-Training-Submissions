using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataModel
{
    public class TblStudent
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(length:200)]
        public string StudentName { get; set; }
        //[Required]
        //public int Age { get; set; }
        //[Required]
        //public string city { get; set; }
        // Foreign key   
        [Display(Name = "TblCourse")]
        public virtual int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual TblCourse Course { get; set; }
    }
}
