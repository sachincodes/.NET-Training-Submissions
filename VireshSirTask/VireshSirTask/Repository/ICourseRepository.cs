using VireshSirTask.Models;

namespace VireshSirTask.Repository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourse();
    }
}
