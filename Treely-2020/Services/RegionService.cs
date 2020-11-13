using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treely_2020.Infrastructure;
using Treely_2020.Models.API;

namespace Treely_2020.Services
{
    public class RegionService
    {

        private readonly RegionContext _context;

        public RegionService(RegionContext context)
        {
            _context = context;
        }


        public Task<IEnumerable<Region>> GetRegions(int count, int skip)
        {
            var regions = _context.Region as IEnumerable<Region>;

            return Task.FromResult(regions);
        }
    }
}
