using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public virtual Course Course { get; set; }

    }
}
