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

        public Ward AddWard(Ward ward)
        {
            return _WardRepository.AddSingleWard(ward);
        }

        public void DeleteWard(int id)
        {
            _WardRepository.DeleteSingleWard(id);
        }

        public List<Ward> GetWardsList()
        {
            return _WardRepository.GetAllWards();
        }

        public Ward UpdateWard(int id, Ward ward)
        {
            return _WardRepository.UpdateSingleWard(id, ward);
        }
    }
}
