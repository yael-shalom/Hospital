using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Services
{
    public interface IWardService
    {
        public Task<IEnumerable<Ward>> GetWardsListAsync();
        public Task<Ward> AddWardAsync(Ward ward);
        public Task<Ward?> UpdateWardAsync(int id, Ward ward);
        public Task DeleteWardAsync(int id);
    }
}
