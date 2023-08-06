using Repository.DbModel;

namespace Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        void AddStudent(Student student);
    }
}