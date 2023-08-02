using StudentCourseWEB.Data;
using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;

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

        public void Add(CourseViewModel course)
        {
            CourseModel courseToAdd = new CourseModel()
            {
                CourseName = course.CourseName
            };
            _context.Courses.Add(courseToAdd);
            _context.SaveChanges();
        }
    }
}
