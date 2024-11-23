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
            _context.Wards.Add(ward);
            _context.SaveChanges(); 
            return ward;
        }

        public void DeleteSingleWard(int id)
        {
            var w = _context.Wards.Find(id);
            _context.Wards.Remove(w);
            _context.SaveChanges(); 
        }

        public List<Ward> GetAllWards()
        {
            return _context.Wards.ToList();
        }

        public Ward? UpdateSingleWard(int id, Ward ward)
        {
            var w = _context.Wards.Find(id);
            if (w != null)
            {
                w.Name = ward.Name;
                _context.SaveChanges(); // Save changes to the database
            }
            return w;
        }
    }
}
