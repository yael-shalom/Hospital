using Hospital.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Placement>> GetAllPlacementsAsync()
        {
            return await _context.Placements.ToListAsync();
        }

        public Placement? GetSinglePlacement(int id)
        {
            return _context.Placements.Find(id);
        }

        public async Task<Placement> AddSinglePlacementAsync(Placement placement)
        {
            _context.Placements.Add(placement);
            await _context.SaveChangesAsync();
            return placement;
        }

        public async Task<Placement?> UpdateSinglePlacementAsync(int id, Placement placement)
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

                await _context.SaveChangesAsync();
            }
            return p;
        }

        public async Task DeleteSinglePlacementAsync(int id)
        {
            var p = _context.Placements.Find(id);

            if (p != null)
            {
                _context.Placements.Remove(p);
                await _context.SaveChangesAsync();
            }
        }

    }
}
