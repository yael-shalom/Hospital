using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Services
{
    public interface IWorkerService
    {
        public List<Worker> GetWorkersList();
        public Worker GetWorkerById(string id);
        public Worker AddWorker(Worker worker);
        public Worker UpdateWorker(string id, Worker worker);
        public void DeleteWorker(string id);
    }
}
