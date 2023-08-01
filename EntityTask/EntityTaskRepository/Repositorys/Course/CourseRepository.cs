using EntityTaskDB;
using Microsoft.EntityFrameworkCore;

namespace EntityTaskRepository.Repositorys.Course
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDBContext _context;

        public CourseRepository(StudentDBContext context)
        {
            _context = context;
        }
        public void Create(Courses courses)
        {
            _context.courses.Add(courses);
            _context.SaveChanges();
        }

        public IEnumerable<Courses> GetAllCourse()
        {
            return _context.courses.ToList();
        }

        public Courses GetByIdCourses(int id)
        {
            var data = _context.courses.FirstOrDefault(x => x.CourseId == id);
            return _context.courses.FirstOrDefault(x => x.CourseId == id);
        }
    }
}
