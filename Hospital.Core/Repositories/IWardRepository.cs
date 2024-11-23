using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Repositories
{
    public interface IWardRepository
    {
        public List<Ward> GetAllWards();
        public Ward AddSingleWard(Ward ward);
        public Ward? UpdateSingleWard(int id, Ward ward);
        public void DeleteSingleWard(int id);
    }
}
