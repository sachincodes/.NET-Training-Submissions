using StudentCourseWEB.Models;
using StudentCourseWEB.Repository;
using StudentCourseWEB.ViewModels;

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

        public void AddCourse(CourseViewModel course)
        {
            _courseRepo.Add(course);
        }
    }
}
