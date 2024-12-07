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
            _context.SaveChanges();
            return worker;
        }

        public void DeleteSingleWorker(string id)
        {
            var w = _context.Workers.Find(id);
            _context.Workers.Remove(w);
            _context.SaveChanges();
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _context.Workers;
        }

        public Worker? GetSingleWorker(string id)
        {
            return _context.Workers.Find(id);
        }

        public Worker? UpdateSingleWorker(string id, Worker worker)
        {
            var w = _context.Workers.Find(id);
            if (w != null)
            {
                w.Name = worker.Name;
                w.Role = worker.Role;

                _context.SaveChanges();
            }
            return w;
        }
    }
}
