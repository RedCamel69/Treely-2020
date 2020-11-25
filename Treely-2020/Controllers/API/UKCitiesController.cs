using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Treely_2020.Models.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treely_2020.Controllers.API
{
    [ApiController]
    [Route("[controller]")]

    //[Route("api/[controller]")]
    //[ApiController]
    public class UKCitiesController : ControllerBase
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public UKCitiesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/<UKCitiesController>
        [HttpGet]
        public List<UKCity> Get()
        {


            string webRootPath = _hostingEnvironment.WebRootPath;

            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"data\\gb.json"}");
            var JSON = System.IO.File.ReadAllText(folderDetails);


            //using (StreamReader sr = new StreamReader(Microsoft.AspNetCore.Hosting.Server.MapPath("~/Content/treatments.json")))
            //{
            //    treatments = JsonConvert.DeserializeObject<List<Treatment>>(sr.ReadToEnd());
            //}

            // var x = RouteData;

            //  string contentRootPath = _hostingEnvironment.ContentRootPath;

            // var JSON = System.IO.File.ReadAllText(HttpContext.Request.h + "/data/gb.json");


            //using (FileStream fs = File.OpenRead(fileName))
            //{
            //    weatherForecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(fs);
            //}


            var cities = JsonSerializer.Deserialize<List<UKCity>>(JSON);


            return cities; // new UKCity();
        }

        // GET api/<UKCitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UKCitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UKCitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UKCitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
