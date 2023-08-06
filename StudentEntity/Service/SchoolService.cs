using AutoMapper;
using Model;
using Repository;
using Repository.DbModel;
using Service.Interface;
using StudentEntity.Model;
using System.Collections.Generic;
using System.Linq;
namespace Service
{


    public class SchoolService : ISchoolService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;


        public SchoolService(ICourseRepository courseRepository, IStudentRepository studentRepository,IMapper mapper)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
             _mapper = mapper ;
        }

        public IEnumerable<CourseModel> GetAllCourses()
        {
            IEnumerable<Course> courses = _courseRepository.GetAllCourses();
            return _mapper.Map<IEnumerable<CourseModel>>(courses);
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
                IEnumerable<Student> students = _studentRepository.GetAllStudents()
                .Select(s => new Student
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName,
                    Age = s.Age,
                    City = s.City
                })
                .ToList();
            return _mapper.Map<IEnumerable<StudentModel>>(students);
        }

        public void AddStudent(StudentModel studentViewModel)
        {
            // Convert view model to database model
            var student = new Student
            {
                StudentName = studentViewModel.StudentName,
                Age = studentViewModel.Age,
                City = studentViewModel.City,
                CourseId = studentViewModel.CourseId
            };

            _studentRepository.AddStudent(student);
        }
    }
}