using StudentCourseWEB.Data;
using StudentCourseWEB.Models;

namespace StudentCourseWEB.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationContext _context;

        public StudentRepo(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(StudentModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return _context.Students.ToList();
        }
    }
}
