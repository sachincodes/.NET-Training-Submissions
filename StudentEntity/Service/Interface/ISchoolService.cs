using Model;
using StudentEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISchoolService
    {
        IEnumerable<StudentModel> GetAllStudents();
        void AddStudent(StudentModel studentViewModel);
        IEnumerable<CourseModel> GetAllCourses();
    }
}
