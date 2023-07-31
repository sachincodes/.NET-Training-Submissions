using StudentCourseWEB.Models;
using StudentCourseWEB.Repository;

namespace StudentCourseWEB.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;

        public CourseService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }
        public IEnumerable<CourseModel> CourseList()
        {
            return _courseRepo.GetAll();
        }
    }
}
