using VireshSirTask.Models;

namespace VireshSirTask.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly MyDbContext _context;
        public CourseRepository(MyDbContext context)
        {
            this._context = context;
        }

        IEnumerable<Course> ICourseRepository.GetCourse()
        {
            return _context.Courses.ToList();   

        }

    

    }
}
