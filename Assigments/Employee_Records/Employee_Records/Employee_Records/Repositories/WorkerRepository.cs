using Employee_Records.Models;
using System.Collections.Concurrent;
using System.Diagnostics.Eventing.Reader;
using Workers_Records.Interfaces;

namespace Workers_Records.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly Dictionary<int, Workers> workers = new Dictionary<int, Workers>();

        public List<Workers> GetAllWorkers()
        {
            return workers.Values.ToList();
        }

        public Workers GetWorkers(int workerId)
        {
            workers.TryGetValue(workerId, out Workers worker);
            return worker;
        }

        public void DeleteWorkers(int workerId)
        {
            workers.Remove(workerId);
        }

        public void SaveWorkers(Workers worker)
        {
            workers[worker.WorkerId] = worker;

        }

        public void UpdateWorkers(Workers worker)
        {
            workers[worker.WorkerId] = worker;
        }

    }
}
