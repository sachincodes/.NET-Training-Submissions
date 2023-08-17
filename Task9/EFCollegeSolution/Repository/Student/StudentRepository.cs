using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentRepository(ApplicationDBContext context)
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
            return _context.students.Include(x => x.Courses).ToList();
        }

    }
}
