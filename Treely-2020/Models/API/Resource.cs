using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Treely_2020.Models.API
{
    public class Resource

    {

        [ForeignKey("RegionID")]

        public int RegionID { get; set; }



        //public Region Region { get; set; }



        public int Id { get; set; }

        public string Name { get; set; }



        public int ResourceTypeId { get; set; }



        public double Lng { get; set; }

        public double Lat { get; set; }



        public string Description { get; set; }



        public string URL { get; set; }



        public ResourceType ResourceTypes { get; set; }



    }
}
