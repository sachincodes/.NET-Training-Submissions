using AutoMapper;
using EntityTaskDB;
using EntityTaskModel;
using EntityTaskRepository.Repositorys.Course;
using EntityTaskRepository.Repositorys.Student;

namespace EntityTaskService.Services.Student
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
        public void CreateStudent(StudentDTO studentDTO)
        {
            Students student = new Students();
            student.StudentName = studentDTO.StudentName;
            student.CourseId = studentDTO.CourseId;
            student.Age = studentDTO.Age;
            student.City = studentDTO.City;
            if (student?.CourseId == null)
            {
                student.CourseId = studentDTO.CourseId;
            }
            _studentRepository.CreateStudent(student);
        }
        public IEnumerable<StudentDTO> GetAllStudent()
        {
            //List<StudentDTO> studentDTOs= new List<StudentDTO>();
            //var data = _studentRepository.GetAllStudents();
            //foreach (var student in data)
            //{
            //    StudentDTO studentDTO = new StudentDTO();
            //    studentDTO.StudentId=student.StudentId;
            //    studentDTO.StudentName = student.StudentName;
            //    studentDTO.CourseId = student.CourseId;
            //    studentDTO.Age = student.Age;
            //    studentDTO.City= student.City;
            //    if (student.CourseId > 0)
            //    {
            //        studentDTO.CourseName = _courseRepository.GetByIdCourses(student.CourseId).CourseName.ToString();
            //    }
            //    studentDTOs.Add(studentDTO);
            //}
            return _mapper.Map<List<StudentDTO>>(_studentRepository.GetAllStudents());
        }
    }
}
