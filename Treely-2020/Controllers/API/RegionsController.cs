using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treely_2020.Infrastructure;
using Treely_2020.Models.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treely_2020.Controllers.API
{
   
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase

    {

        private RegionContext _context { get; set; }



        public RegionsController(RegionContext context)

        {

            _context = context;

        }



        // GET: api/Regions

        [HttpGet]

        public IEnumerable<Region> Get()

        {

            var res = _context.Region.Include(x => x.Resources);

            return res; // new string[] { "value1", "value2" };

        }



        // GET: api/Regions/5

        [HttpGet("{id}", Name = "Get")]

        public string Get(int id)

        {

            return "value";

        }



        // POST: api/Regions

        [HttpPost]

        public void Post([FromBody] string value)

        {

        }



        // PUT: api/Regions/5

        [HttpPut("{id}")]

        public void Put(int id, [FromBody] string value)

        {

        }



        // DELETE: api/Regions/5

        [HttpDelete("{id}")]

        public void Delete(int id)

        {

        }

    }
}
