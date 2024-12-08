using Hospital.Core.Repositories;
using Hospital.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class WardService : IWardService
    {
        private readonly IWardRepository _WardRepository;
        public WardService(IWardRepository wardRepository)
        {
            _WardRepository = wardRepository;
        }

        public async Task<Ward> AddWardAsync(Ward ward)
        {
            return await _WardRepository.AddSingleWardAsync(ward);
        }

        public async Task DeleteWardAsync(int id)
        {
            await _WardRepository.DeleteSingleWardAsync(id);
        }

        public async Task<IEnumerable<Ward>> GetWardsListAsync()
        {
            return await _WardRepository.GetAllWardsAsync();
        }

        public async Task<Ward?> UpdateWardAsync(int id, Ward ward)
        {
            return await _WardRepository.UpdateSingleWardAsync(id, ward);
        }
    }
}
