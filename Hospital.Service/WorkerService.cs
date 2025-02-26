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
            bool isValid = false;
            int id;
            string idW = worker.Id;
            if (int.TryParse(worker.Id, out id)) 
            {
                isValid = true;
                // בודק אם אורך המחרוזת עד 9 תווים
                if (idW.Length > 9)
                {
                    isValid = false;
                }

                // בודק אם כל התווים במחרוזת הם ספרות
                foreach (char c in idW)
                {
                    if (!char.IsDigit(c))
                    {
                        isValid = false;
                    }
                }

                if (!isValid)
                    return null;

                isValid = false;

                //בדיקת תקינות תז
                int digit, sum = 0;
                int checksum = id % 10;
                id /= 10;
                for (int i = 0; i < 8; i++)
                {
                    digit = id % 10;
                    id /= 10;
                    if (i % 2 == 0)
                        digit *= 2;
                    if (digit > 9)
                        digit = digit / 10 + digit % 10;
                    sum += digit;
                }
                if ((10 - sum % 10) == checksum)
                    isValid = true;
            }
            var workers = await _WorkerRepository.GetAllWorkersAsync();
            var wrkr = workers.FirstOrDefault(w => w.Id.Equals(worker.Id) || (w.UserName.Equals(worker.UserName)&&w.Password.Equals(worker.Password)));//בדיקה שהעובד ושם המשתמש-סיסמא לא קיים
            if (wrkr == null && isValid && worker.Role!=eRole.manager)
                return await _WorkerRepository.AddSingleWorkerAsync(worker);
            return null;
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
