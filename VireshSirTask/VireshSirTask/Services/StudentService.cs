
using VireshSirTask.Repository;
using VireshSirTask.Models;
using VireshSirTask.Models.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VireshSirTask.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
         public  StudentService(IStudentRepository studentRepository , ICourseRepository courseRepository)
        {
            this._studentRepository = studentRepository;    
            this._courseRepository = courseRepository;  
        }
      

        IEnumerable<StudentView> IStudentService.GetStudentDetails()
        {
                     var students =  _studentRepository.GetStudents();
                    var courses = _courseRepository.GetCourse();

            var coursewithstudents = (from course in courses
                                      join student in students on course.CourseId
                                      equals student.CourseId
                                      select new StudentView
                                      {
                                          StudentName = student.StudentName,
                                          Age = student.Age,
                                          Course = course.CourseName,
                                          City = student.City
                                      }).ToList();


            return coursewithstudents; 
        }

 

        void IStudentService.SavetToDB(StudentView student)
        {
            _studentRepository.AddToDB(student); 
        }
    }
}
