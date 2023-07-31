using StudentCourseWEB.Models;

namespace StudentCourseWEB.Repository
{
    public interface IStudentRepo
    {
        IEnumerable<StudentModel> GetAll();
        void Add(StudentModel student);
    }
}
