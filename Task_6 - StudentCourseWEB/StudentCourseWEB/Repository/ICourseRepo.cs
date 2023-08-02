using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Repository
{
    public interface ICourseRepo
    {
        IEnumerable<CourseModel> GetAll();

        void Add(CourseViewModel course);
    }
}
