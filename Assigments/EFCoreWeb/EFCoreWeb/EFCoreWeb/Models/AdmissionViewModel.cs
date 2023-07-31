using EFCoreModels;

namespace EFCoreWeb.Models
{
    public class AdmissionViewModel
    {
        public int SelectCourseId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public List<CourseViewModel> Courses { get; set; }
    }
}
