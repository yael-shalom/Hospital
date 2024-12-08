using Hospital.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public class WardRepository : IWardRepository
    {
        private readonly DataContext _context;

        public WardRepository(DataContext context)
        { 
            _context = context;
        }

        public async Task<Ward> AddSingleWardAsync(Ward ward)
        {
            _context.Wards.Add(ward);
            await _context.SaveChangesAsync(); 
            return ward;
        }

        public async Task DeleteSingleWardAsync(int id)
        {
            var w = _context.Wards.Find(id);
            _context.Wards.Remove(w);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Ward>> GetAllWardsAsync()
        {
            return await _context.Wards.ToListAsync();
        }

        public async Task<Ward?> UpdateSingleWardAsync(int id, Ward ward)
        {
            var w = _context.Wards.Find(id);
            if (w != null)
            {
                w.Name = ward.Name;
                await _context.SaveChangesAsync(); // Save changes to the database
            }
            return w;
        }
    }
}
