using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treely_2020.Infrastructure;
using Treely_2020.Models;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebEssentials.AspNetCore.Pwa;

namespace Treely_2020.Controllers
{
    public class MappyController : Controller
    {
        private readonly ILogger<MappyController> _logger;

        private RegionContext _cxt;

        private readonly WebManifest _manifest;

        public MappyController(ILogger<MappyController> logger, RegionContext cx, WebManifest manifest)

        {

            _logger = logger;
            _cxt = cx;
            _manifest = manifest;

        }
        // GET: MappyController
        public async Task<IActionResult> Index()

        {



            RegionsViewModel vm = new RegionsViewModel();



            List<Region> Regions = new List<Region>();


            using (var client = new HttpClient())

            {

                //Passing service base url 

                client.BaseAddress = new Uri("https://localhost:44356/");



                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                //Sending request to find web api REST service resource GetDepartments using HttpClient 

                HttpResponseMessage Res = await client.GetAsync("regions");



                //Checking the response is successful or not which is sent using HttpClient 

                if (Res.IsSuccessStatusCode)

                {



                    var ObjResponse = Res.Content.ReadAsStringAsync().Result;

                    vm.Regions = JsonConvert.DeserializeObject<List<Region>>(ObjResponse);



                }

                //returning the student list to view 

                return View(vm);

            }

            return View(vm);

        }

        // GET: MappyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MappyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MappyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MappyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MappyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MappyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MappyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
