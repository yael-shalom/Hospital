using Hospital.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _context;

        public WorkerRepository(DataContext context)
        {
            _context = context;
        }
        public Worker AddSingleWorker(Worker worker)
        {

            _context.Workers.Add(worker);
            return worker;
        }

        public void DeleteSingleWorker(string id)
        {
            int index = _context.Workers.FindIndex(w => w.Id.Equals(id));
            _context.Workers.Remove(_context.Workers[index]);
        }

        public List<Worker> GetAllWorkers()
        {
            return _context.Workers;
        }

        public Worker GetSingleWorker(string id)
        {
            return (Worker)_context.Workers.Where(w => w.Id.Equals(id));
        }

        public Worker UpdateSingleWorker(string id, Worker worker)
        {
            int index = _context.Workers.FindIndex(w => w.Id.Equals(id));
            _context.Workers[index].Name = worker.Name;
            _context.Workers[index].Role = worker.Role;
            return _context.Workers[index];
        }
    }
}
