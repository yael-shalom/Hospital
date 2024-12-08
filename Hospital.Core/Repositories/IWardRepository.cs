using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories
{
    public interface IWardRepository
    {
        public Task<IEnumerable<Ward>> GetAllWardsAsync();
        public Task<Ward> AddSingleWardAsync(Ward ward);
        public Task<Ward?> UpdateSingleWardAsync(int id, Ward ward);
        public Task DeleteSingleWardAsync(int id);
    }
}
