using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories
{
    public interface IPlacementRepository
    {
        public Task<IEnumerable<Placement>> GetAllPlacementsAsync();
        public Placement? GetSinglePlacement(int id);
        public Task<Placement> AddSinglePlacementAsync(Placement placement);
        public Task<Placement?> UpdateSinglePlacementAsync(int id, Placement placement);
        public Task DeleteSinglePlacementAsync(int id);
    }
}
