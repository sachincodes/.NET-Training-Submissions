using StudentCourseWEB.Models;

namespace StudentCourseWEB.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetAllStudents();
        void AddStudent(StudentModel student);
    }
}
