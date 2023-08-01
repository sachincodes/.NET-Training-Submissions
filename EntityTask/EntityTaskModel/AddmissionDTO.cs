using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTaskModel
{
    public class AddmissionDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public List<CourseDTO>? courses { get; set; }
    }
}
