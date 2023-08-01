using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityTaskModel
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public virtual CourseDTO? courses { get; set; }  
    }
}
