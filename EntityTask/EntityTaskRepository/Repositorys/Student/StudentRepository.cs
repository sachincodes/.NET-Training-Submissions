using EntityTaskDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTaskRepository.Repositorys.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _context;

        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }
        public void CreateStudent(Students students)
        {
            _context.students.Add(students);
            _context.SaveChanges();
        }
        public IEnumerable<Students> GetAllStudents()
        {
            return _context.students.Include(x=>x.courses).ToList();
        }

    }
}
