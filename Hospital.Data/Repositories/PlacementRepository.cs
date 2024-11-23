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
            return _context.Placements.ToList();
        }

        public Placement? GetSinglePlacement(int id)
        {
            return _context.Placements.Find(id);
        }

        public Placement AddSinglePlacement(Placement placement)
        {
            _context.Placements.Add(placement);
            _context.SaveChanges();
            return placement;
        }

        public Placement UpdateSinglePlacement(int id, Placement placement)
        {
            var p = _context.Placements.Find(id);

            if (p != null)
            {
                p.Day = placement.Day;
                p.Morning = placement.Morning;
                p.Evening = placement.Evening;
                p.Night = placement.Night;
                p.WardId = placement.WardId;
                p.WorkerId = placement.WorkerId;

                _context.SaveChanges();
            }
            return p;
        }

        public void DeleteSinglePlacement(int id)
        {
            var p = _context.Placements.Find(id);
            _context.Placements.Remove(p);
            _context.SaveChanges();
        }

    }
}
