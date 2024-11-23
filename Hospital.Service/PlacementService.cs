using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Repositories;
using Hospital.Core.Services;

namespace Hospital.Service
{
    public class PlacementService : IPlacementService
    {
        private readonly IPlacementRepository _PlacementRepository;
       
        public PlacementService(IPlacementRepository placementRepository)
        {
            _PlacementRepository = placementRepository;
        }

        public List<Placement> GetPlacementsList()
        {
            return _PlacementRepository.GetAllPlacements();
        }

        public Placement addPlacement(Placement placement)
        {
            return _PlacementRepository.addSinglePlacement(placement);
        }

        public void deletePlacement(string id)
        {
            _PlacementRepository.deleteSinglePlacement(id);
        }

        public List<Placement> GetPlacementById(string id)
        {
            return _PlacementRepository.GetSinglePlacement(id);
        }

        public Placement updatePlacement(string id, Placement placement)
        {
            return _PlacementRepository.updateSinglePlacement(id, placement);
        }
    }
}
