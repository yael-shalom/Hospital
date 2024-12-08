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

        public async Task<Worker> AddWorkerAsync(Worker worker)
        {
            return await _WorkerRepository.AddSingleWorkerAsync(worker);
        }

        public async Task DeleteWorkerAsync(string id)
        {
            await _WorkerRepository.DeleteSingleWorkerAsync(id);
        }

        public Worker GetWorkerById(string id)
        {
            return _WorkerRepository.GetSingleWorker(id);
        }

        public async Task<IEnumerable<Worker>> GetWorkersListAsync()
        {
            return await _WorkerRepository.GetAllWorkersAsync();
        }

        public async Task<Worker?> UpdateWorkerAsync(string id, Worker worker)
        {
            return await _WorkerRepository.UpdateSingleWorkerAsync(id, worker);
        }
    }
}
