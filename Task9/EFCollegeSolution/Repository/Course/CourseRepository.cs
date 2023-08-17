using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Course
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDBContext _context;

        public CourseRepository(ApplicationDBContext context)
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
