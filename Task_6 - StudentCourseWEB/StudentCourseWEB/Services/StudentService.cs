using StudentCourseWEB.Models;
using StudentCourseWEB.Repository;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public void AddStudent(StudentViewModel student)
        {
            _studentRepo.Add(student);
        }

        public IEnumerable<StudentViewModel> GetAllStudents()
        {
            return _studentRepo.GetAll();
        }
    }
}
