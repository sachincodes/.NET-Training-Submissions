using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Service.Course
{
    public interface ICourseService
    {
        public IEnumerable<Models.Course> GetAllCourses();
        public Models.Course GetByIdCourses(int id);
        public void Create(Models.Course courses);
    }
}
