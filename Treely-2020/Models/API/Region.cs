using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Treely_2020.Models.API
{
    public class Region
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int PercentageCover { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}
