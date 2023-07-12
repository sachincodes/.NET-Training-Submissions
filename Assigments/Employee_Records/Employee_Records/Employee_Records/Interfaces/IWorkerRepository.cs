using Employee_Records.Models;

namespace Workers_Records.Interfaces
{
    public interface IWorkerRepository
    {
        List<Workers> GetAllWorkers();
        Workers GetWorkers(int workerId);
        void DeleteWorkers(int workerId);
        void SaveWorkers(Workers workers);
        void UpdateWorkers(Workers workers);
    }
}
