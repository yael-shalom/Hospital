using Hospital.Core.Repositories;
using Hospital.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _WorkerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _WorkerRepository = workerRepository;
        }

        public Worker AddWorker(Worker worker)
        {
            return _WorkerRepository.AddSingleWorker(worker);
        }

        public void DeleteWorker(string id)
        {
            _WorkerRepository.DeleteSingleWorker(id);
        }

        public Worker GetWorkerById(string id)
        {
            return _WorkerRepository.GetSingleWorker(id);
        }

        public IEnumerable<Worker> GetWorkersList()
        {
            return _WorkerRepository.GetAllWorkers();
        }

        public Worker UpdateWorker(string id, Worker worker)
        {
            return _WorkerRepository.UpdateSingleWorker(id, worker);
        }
    }
}
