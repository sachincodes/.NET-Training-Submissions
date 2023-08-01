using EntityTaskDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTaskRepository.Repositorys.Student
{
    public interface IStudentRepository
    {
        public IEnumerable<Students> GetAllStudents();
        public void CreateStudent(Students students);
    }
}
