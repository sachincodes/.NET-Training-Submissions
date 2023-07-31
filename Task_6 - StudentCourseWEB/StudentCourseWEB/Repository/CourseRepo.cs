using StudentCourseWEB.Data;
using StudentCourseWEB.Models;

namespace StudentCourseWEB.Repository
{
    public class CourseRepo : ICourseRepo
    {
        private readonly ApplicationContext _context;

        public CourseRepo(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<CourseModel> GetAll()
        {
            return _context.Courses.ToList();
        }
    }
}
