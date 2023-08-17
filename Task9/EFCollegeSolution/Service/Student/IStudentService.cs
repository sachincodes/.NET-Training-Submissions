using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Service.Student
{
    public interface IStudentService
    {
        public IEnumerable<Models.Student> GetAllStudent();
        public void CreateStudent(Models.Student studentDTO);
    }
}
