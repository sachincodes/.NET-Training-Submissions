using StudentCourseWEB.Models;

namespace StudentCourseWEB.Services
{
    public interface ICourseService
    {
        public IEnumerable<CourseModel> CourseList();
    }
}
