using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Services
{
    public interface IWorkerService
    {
        public Task<IEnumerable<Worker>> GetWorkersListAsync();
        public Worker GetWorkerById(string id);
        public Task<Worker> AddWorkerAsync(Worker worker);
        public Task<Worker?> UpdateWorkerAsync(string id, Worker worker);
        public Task DeleteWorkerAsync(string id);
    }
}
