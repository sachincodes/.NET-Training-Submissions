using EntityTaskModel;

namespace EntityTaskService.Services.Course
{
    public interface ICourseService
    {
        public IEnumerable<CourseDTO> GetAllCourses();
        public CourseDTO GetByIdCourses(int id);
        public void Create(CourseDTO courseDTOs);
    }
}
