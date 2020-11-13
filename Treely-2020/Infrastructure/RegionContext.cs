using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treely_2020.Models.API;

namespace Treely_2020.Infrastructure
{
    public class RegionContext : DbContext

    {

        public RegionContext(DbContextOptions<RegionContext> options) : base(options)

        {

        }



        public DbSet<Region> Region { get; set; }



        public DbSet<Resource> Resource { get; set; }



        public DbSet<ResourceType> ResourceType { get; set; }



    }
}
