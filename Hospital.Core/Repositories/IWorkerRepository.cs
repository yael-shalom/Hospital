using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories
{
    public interface IWorkerRepository
    {
        public List<Worker> GetAllWorkers();
        public Worker? GetSingleWorker(string id);
        public Worker AddSingleWorker(Worker worker);
        public Worker UpdateSingleWorker(string id, Worker worker);
        public void DeleteSingleWorker(string id);
    }
}
