using Hospital.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public class PlacementRepository : IPlacementRepository
    {
        private readonly DataContext _context;
        public PlacementRepository(DataContext context) 
        { 
            _context = context; 
        }

        public List<Placement> GetAllPlacements()
        {
            return _context.Placements;
        }

        public List<Placement> GetSinglePlacement(string id)
        {
            return _context.Placements.FindAll(p => p.IdWorker.Equals(id));
        }
        
        public Placement addSinglePlacement(Placement placement)
        {
            _context.Placements.Add(placement);
            return placement;
        }

        public Placement updateSinglePlacement(string id, Placement placement)
        {
            int index = _context.Placements.FindIndex(p => p.IdWorker.Equals(id));
            _context.Placements[index].Day = placement.Day;
            _context.Placements[index].Morning = placement.Morning;
            _context.Placements[index].Evening = placement.Evening;
            _context.Placements[index].Night = placement.Night;
            _context.Placements[index].Idward = placement.Idward;
            return _context.Placements[index];
        }

        public void deleteSinglePlacement(string id)
        {
            int index = _context.Placements.FindIndex(w => w.IdWorker.Equals(id));
            _context.Placements.Remove(_context.Placements[index]);
        }

    }
}
