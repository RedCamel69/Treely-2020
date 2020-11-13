using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treely_2020.Models.API;

namespace Treely_2020.Models
{
    public class Region

    {

        public int Id { get; set; }



        public string Name { get; set; }



        public int PercentageCover { get; set; }



        public ICollection<Resource> Resources { get; set; }



        public bool Selected { get; set; }

    }
}
