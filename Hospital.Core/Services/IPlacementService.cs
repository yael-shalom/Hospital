using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Services
{
    public interface IPlacementService
    {
        public Task<IEnumerable<Placement>> GetPlacementsListAsync();
        public Placement GetPlacementById(int id);
        public Task<Placement> AddPlacementAsync(Placement placement);
        public Task<Placement?> UpdatePlacementAsync(int id, Placement placement);
        public Task DeletePlacementAsync(int id);
    }
}
