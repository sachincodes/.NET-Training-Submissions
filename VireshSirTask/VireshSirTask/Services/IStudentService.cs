using VireshSirTask.Models;

namespace VireshSirTask.Services
{
    public interface IStudentService
    {
        void SavetToDB(Models.ViewModel.StudentView student);
        IEnumerable<Models.ViewModel.StudentView> GetStudentDetails();
    }
}
