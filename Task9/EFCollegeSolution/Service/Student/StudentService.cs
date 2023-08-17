using AutoMapper;
using Repository.Course;
using Repository.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = Mapping.Mapper;
        }
        public void CreateStudent(Models.Student student)
        {
            Students students = new Students();
            student.StudentName = student.StudentName;
            student.CourseId = student.CourseId;
            student.Age = student.Age;
            student.City = student.City;
            if (student?.CourseId == null)
            {
                student.CourseId = student.CourseId;
            }
            _studentRepository.CreateStudent(students);
        }

   

        public IEnumerable<Models.Student> GetAllStudent()
        {

            return _mapper.Map<List<Models.Student>>(_studentRepository.GetAllStudents());
        }

    }
}
