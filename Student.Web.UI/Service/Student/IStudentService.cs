using Model.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Student
{
   public interface IStudentService
    {
        List<StudentModel> GetAllStudent();
        bool AddStudent(StudentModel model);
    }
}
