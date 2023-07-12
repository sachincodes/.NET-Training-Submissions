using Employee_Records.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Workers_Records.Interfaces;

namespace Workers_Records.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerController(IWorkerRepository workerRepository)
        {
            this._workerRepository = workerRepository;
        }
        public IActionResult Index()
        {
            var workers = _workerRepository.GetAllWorkers();
            return View(workers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Workers worker)
        {
            if (ModelState.IsValid)
            {
                _workerRepository.SaveWorkers(worker);

                return RedirectToAction("Index");
            }

            return View(worker);
        }

        public IActionResult Edit(int workerId)
        {
            var worker = _workerRepository.GetWorkers(workerId);
            if (worker == null)
            {
                return null;
            }
            return View(worker);
        }

        [HttpPost]
        public IActionResult Edit(Workers worker)
        {
            if (ModelState.IsValid)
            {
                _workerRepository.UpdateWorkers(worker);
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        public IActionResult Delete(int workerId)
        {
            var worker = _workerRepository.GetWorkers(workerId);
            if (worker == null)
            {
                return null;
            }
            return View(worker);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int workerId)
        {
            _workerRepository.DeleteWorkers(workerId);
            return RedirectToAction("Index");
        }

    }
}
