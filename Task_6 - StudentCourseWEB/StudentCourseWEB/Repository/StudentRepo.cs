using StudentCourseWEB.Data;
using StudentCourseWEB.Models;
using StudentCourseWEB.ViewModels;

namespace StudentCourseWEB.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationContext _context;

        public StudentRepo(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(StudentViewModel student)
        {

            StudentModel stud = new StudentModel()
            {
                StudentName = student.StudentName,
                StudentAge = student.StudentAge,
                StudentCity = student.StudentCity,
                CourseId = student.CourseId,
            };

            _context.Students.Add(stud);
            _context.SaveChanges();
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            IEnumerable<StudentModel> students = _context.Students.ToList();

            List<StudentViewModel> studs = new List<StudentViewModel>();

            foreach (var item in students)
            {
                studs.Add(new StudentViewModel()
                {
                    StudentName = item.StudentName,
                    StudentAge = item.StudentAge,
                    StudentCity = item.StudentCity,
                    CourseId = item.CourseId
                });
            }

            return studs;
        }
    }
}
