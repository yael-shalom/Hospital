using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories
{
    public interface IWorkerRepository
    {
        public Task<IEnumerable<Worker>> GetAllWorkersAsync();
        public Worker? GetSingleWorker(string id);
        public Task<Worker> AddSingleWorkerAsync(Worker worker);
        public Task<Worker?> UpdateSingleWorkerAsync(string id, Worker worker);
        public Task DeleteSingleWorkerAsync(string id);
    }
}
