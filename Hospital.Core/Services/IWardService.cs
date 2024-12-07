using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Services
{
    public interface IWardService
    {
        public IEnumerable<Ward> GetWardsList();
        public Ward AddWard(Ward ward);
        public Ward UpdateWard(int id, Ward ward);
        public void DeleteWard(int id);
    }
}
