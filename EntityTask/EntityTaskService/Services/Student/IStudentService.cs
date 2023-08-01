using EntityTaskDB;
using EntityTaskModel;

namespace EntityTaskService.Services.Student
{
    public interface IStudentService
    {
        public IEnumerable<StudentDTO> GetAllStudent();
        public void CreateStudent(StudentDTO studentDTO);
    }
}
