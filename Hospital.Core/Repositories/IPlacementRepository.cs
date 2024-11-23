using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories
{
    public interface IPlacementRepository
    {
        public List<Placement> GetAllPlacements();
        public List<Placement> GetSinglePlacement(string id);
        public Placement addSinglePlacement(Placement placement);
        public Placement updateSinglePlacement(string id, Placement placement);
        public void deleteSinglePlacement(string id);
    }
}
