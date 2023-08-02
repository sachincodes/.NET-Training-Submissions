using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentViewModel> GetAllStudents();
        void AddStudent(StudentViewModel student);
    }
}
