using StudentCourseWEB.Models;

namespace StudentCourseWEB.Repository
{
    public interface ICourseRepo
    {
        IEnumerable<CourseModel> GetAll();
    }
}
