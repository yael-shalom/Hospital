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
        public Placement? GetSinglePlacement(int id);
        public Placement AddSinglePlacement(Placement placement);
        public Placement UpdateSinglePlacement(int id, Placement placement);
        public void DeleteSinglePlacement(int id);
    }
}
