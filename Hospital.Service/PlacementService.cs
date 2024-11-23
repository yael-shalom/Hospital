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

        public Placement AddPlacement(Placement placement)
        {
            return _PlacementRepository.AddSinglePlacement(placement);
        }

        public void DeletePlacement(int id)
        {
            _PlacementRepository.DeleteSinglePlacement(id);
        }

        public Placement? GetPlacementById(int id)
        {
            return _PlacementRepository.GetSinglePlacement(id);
        }

        public Placement UpdatePlacement(int id, Placement placement)
        {
            return _PlacementRepository.UpdateSinglePlacement(id, placement);
        }
    }
}
