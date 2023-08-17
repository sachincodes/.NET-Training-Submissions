using Repository.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using AutoMapper;

namespace Service.Course
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
        public void Create(Models.Course courseDTOs)
        {
            Courses course = new Courses();
            course.CourseName = courseDTOs.CourseName;
            _courseRepository.Create(course);
        }

        public Models.Course GetByIdCourses(int id)
        {
            var data = _courseRepository.GetByIdCourses(id);
            Models.Course course = new Models.Course();
            course.CourseName = data.CourseName;
            course.CourseName = data.CourseName;
            return course;
        }

        IEnumerable<Models.Course> ICourseService.GetAllCourses()
        {
            List<Models.Course> courseDTOs = new List<Models.Course>();
            var data = _courseRepository.GetAllCourse();
            foreach (var course in data)
            {
                Models.Course courseDTO = new Models.Course();
                courseDTO.CourseId = course.CourseId;
                courseDTO.CourseName = course.CourseName;
                courseDTOs.Add(courseDTO);
            }
            return courseDTOs;
        }
    }
}
