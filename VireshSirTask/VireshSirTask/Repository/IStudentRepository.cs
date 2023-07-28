using VireshSirTask.Models.ViewModel;
using VireshSirTask.Services;
using VireshSirTask.Models;
namespace VireshSirTask.Repository
{
    public interface IStudentRepository
    {
        void AddToDB(StudentView student);
        IEnumerable<Student> GetStudents(); 


    }
}
