using EFCoreModels;

namespace EFCoreRepository
{
    public class RepositoryClass
    {
        private readonly EFCoreContext _dbContext;

        public RepositoryClass(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _dbContext.Courses
                .FirstOrDefault(c => c.CourseId == id);
        }

        public void AddCourse(Course course)
        {
            _dbContext.Add(course);
            _dbContext.SaveChanges();
        }

        public void AddStudents(Student student)
        {
            _dbContext.Add(student);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }
    }
}