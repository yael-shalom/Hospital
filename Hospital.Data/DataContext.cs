using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data
{
    public class DataContext
    {
        public List<Placement> Placements { get; set; }
        public List<Ward> Wards { get; set; }
        public List<Worker> Workers { get; set; }

        public DataContext() 
        {
            Placements = new List<Placement> 
            {
                new Placement{}
            };

            Wards = new List<Ward>
            {
                new Ward{}
            };

            Workers = new List<Worker>
            { 
                new Worker{}
            };
        }
    }
}
