using EntityTaskDB;

namespace EntityTaskRepository.Repositorys.Course
{
    public interface ICourseRepository
    {
        public IEnumerable<Courses> GetAllCourse();
        public Courses GetByIdCourses(int id);
        public void Create(Courses courses);
    }
}
