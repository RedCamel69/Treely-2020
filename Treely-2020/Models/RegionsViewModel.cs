using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treely_2020.Models
{
    public class RegionsViewModel
    {
       public List<Region> Regions { get; set; }

        public RegionsViewModel()
        {
            Regions = new List<Region>();
        }
    }
}
