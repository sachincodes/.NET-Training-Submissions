using VireshSirTask.Models;
using VireshSirTask.Models.ViewModel;

namespace VireshSirTask.Repository
{
    public class StudentRepository : IStudentRepository
    {     private readonly MyDbContext _context;    
        public StudentRepository(MyDbContext context)
        {
            this._context = context;    
        }
        void IStudentRepository.AddToDB(StudentView student)
        {
            var course=   _context.Courses.FirstOrDefault((course) => course.CourseName == student.Course);
      
              Student studentnew = new Student();
          studentnew.Age = student.Age;
            studentnew.City = student.City;   
            studentnew.CourseId = course.CourseId; 
            studentnew.StudentName = student.StudentName;
            _context.Students.Add(studentnew);
            _context.SaveChanges();
        }

      

        IEnumerable<Student> IStudentRepository.GetStudents()
        {
          


            return _context.Students;
        }
    }
}
