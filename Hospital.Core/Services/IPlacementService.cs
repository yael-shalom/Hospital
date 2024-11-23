using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Services
{
    public interface IPlacementService
    {
        public List<Placement> GetPlacementsList();
        public Placement GetPlacementById(int id);
        public Placement AddPlacement(Placement placement);
        public Placement UpdatePlacement(int id, Placement placement);
        public void DeletePlacement(int id);
    }
}
