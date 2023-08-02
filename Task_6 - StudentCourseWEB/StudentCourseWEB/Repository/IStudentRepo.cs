using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Repository
{
    public interface IStudentRepo
    {
        IEnumerable<StudentViewModel> GetAll();
        void Add(StudentViewModel student);
    }
}
