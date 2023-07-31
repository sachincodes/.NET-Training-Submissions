using EFCoreModels;
using EFCoreRepository;

namespace EFCoreServices
{
    public class ServiceClass
    {
        private readonly RepositoryClass _repository;

        public ServiceClass(RepositoryClass repository)
        {
            _repository= repository;
        }

        public IEnumerable<Course> GetAllCourses()
        {
           return _repository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _repository.GetCourseById(id);
        }

        public void AddCourse(Course course)
        {
            _repository.AddCourse(course);
        }

        public void AddStudents(Student student)
        {
            _repository.AddStudents(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }

    }
}