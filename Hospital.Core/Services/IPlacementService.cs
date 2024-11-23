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
        public List<Placement> GetPlacementById(string id);
        public Placement addPlacement(Placement placement);
        public Placement updatePlacement(string id, Placement placement);
        public void deletePlacement(string id);
    }
}
