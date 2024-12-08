using Hospital.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Worker> AddSingleWorkerAsync(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            return worker;
        }

        public async Task DeleteSingleWorkerAsync(string id)
        {
            var w = _context.Workers.Find(id);
            _context.Workers.Remove(w);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await _context.Workers.ToListAsync();
        }

        public Worker? GetSingleWorker(string id)
        {
            return _context.Workers.Find(id);
        }

        public async Task<Worker?> UpdateSingleWorkerAsync(string id, Worker worker)
        {
            var w = _context.Workers.Find(id);
            if (w != null)
            {
                w.Name = worker.Name;
                w.Role = worker.Role;

                await _context.SaveChangesAsync();
            }
            return w;
        }
    }
}
