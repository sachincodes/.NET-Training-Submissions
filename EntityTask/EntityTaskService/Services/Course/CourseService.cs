using AutoMapper;
using EntityTaskDB;
using EntityTaskModel;
using EntityTaskRepository.Repositorys.Course;

namespace EntityTaskService.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = Mapping.Mapper;
        }
        public void Create(CourseDTO courseDTOs)
        {
            Courses course = new Courses();
            course.CourseName = courseDTOs.CourseName;
            _courseRepository.Create(course);
        }

        public CourseDTO GetByIdCourses(int id)
        {
            var data = _courseRepository.GetByIdCourses(id);
            CourseDTO course = new CourseDTO();
            course.CourseName = data.CourseName;
            course.CourseName= data.CourseName;
            return course;
        }

        IEnumerable<CourseDTO> ICourseService.GetAllCourses()
        {
            List<CourseDTO> courseDTOs = new List<CourseDTO>();
            var data = _courseRepository.GetAllCourse();
            foreach (var course in data)
            {
                CourseDTO courseDTO = new CourseDTO();
                courseDTO.CourseId = course.CourseId;
                courseDTO.CourseName = course.CourseName;
                courseDTOs.Add(courseDTO);
            }
            return courseDTOs;
        }
    }
}
