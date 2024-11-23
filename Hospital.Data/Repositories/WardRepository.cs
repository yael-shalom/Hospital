using Hospital.Core.Repositories;
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

        public Ward AddSingleWard(Ward ward)
        {
            if (_context.Wards.Count == 0)
                ward.Id = 1;
            else
                ward.Id = _context.Wards.Last().Id + 1;
            _context.Wards.Add(ward);
            return ward;
        }

        public void DeleteSingleWard(int id)
        {
            int index = _context.Wards.FindIndex(w => w.Id == id);
            _context.Wards.Remove(_context.Wards[index]);
        }

        public List<Ward> GetAllWards()
        {
            return _context.Wards;
        }

        public Ward UpdateSingleWard(int id, Ward ward)
        {
            int index = _context.Wards.FindIndex(w => w.Id == id);
            _context.Wards[index].Name = ward.Name;
            return _context.Wards[index];
        }
    }
}
