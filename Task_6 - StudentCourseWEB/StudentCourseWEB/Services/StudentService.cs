using StudentCourseWEB.Models;
using StudentCourseWEB.Repository;

namespace StudentCourseWEB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public void AddStudent(StudentModel student)
        {
            _studentRepo.Add(student);
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            return _studentRepo.GetAll();
        }
    }
}
