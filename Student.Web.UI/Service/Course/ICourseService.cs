using Model.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Course
{
   public interface ICourseService
    {
        List<CourseModel> GetAllCourse();
        bool AddCourse(CourseModel model);
    }
}
