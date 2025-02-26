using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital
{
    public class Worker
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public eRole Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public enum eRole
    {
        manager, doctor, surgeon, cleaner, auxiliaryPower, secretary, nurse, midwife
    }
}
