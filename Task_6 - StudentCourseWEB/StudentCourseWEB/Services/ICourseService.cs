using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Services
{
    public interface ICourseService
    {
        public IEnumerable<CourseModel> CourseList();
        public void AddCourse(CourseViewModel course);
    }
}
