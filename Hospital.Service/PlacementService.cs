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

        public async Task<IEnumerable<Placement>> GetPlacementsListAsync()
        {
            return await _PlacementRepository.GetAllPlacementsAsync();
        }

        public async Task<Placement> AddPlacementAsync(Placement placement)
        {
            return await _PlacementRepository.AddSinglePlacementAsync(placement);
        }

        public async Task DeletePlacementAsync(int id)
        {
            await _PlacementRepository.DeleteSinglePlacementAsync(id);
        }

        public Placement? GetPlacementById(int id)
        {
            return _PlacementRepository.GetSinglePlacement(id);
        }

        public async Task<Placement?> UpdatePlacementAsync(int id, Placement placement)
        {
            return await _PlacementRepository.UpdateSinglePlacementAsync(id, placement);
        }
    }
}
