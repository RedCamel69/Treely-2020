using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treely_2020.Models.API;
using Treely_2020.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Treely_2020.Controllers.Admin
{
    public class ResourcesController : Controller

    {

        private readonly RegionContext _context;



        public ResourcesController(RegionContext context)

        {

            _context = context;

        }



        // GET: Resources

        public async Task<IActionResult> Index()

        {

            return View(await _context.Resource.ToListAsync());

        }



        // GET: Resources/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource.FirstOrDefaultAsync(m => m.Id == id);

            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);

        }



        // GET: Resources/Create

        public IActionResult Create()

        {







            List<SelectListItem> ids = new List<SelectListItem>();

            List<SelectListItem> resourceTypeIds = new List<SelectListItem>();



            var regions = _context.Region.ToList();



            foreach (var region in regions)

            {

                ids.Add(new SelectListItem() { Value = region.ID.ToString(), Text = region.Name.ToString() });

            }



            ViewData["Numbers"] = ids;



            var resourcetypes = _context.ResourceType.ToList();



            foreach (var resourcetype in resourcetypes)

            {

                resourceTypeIds.Add(new SelectListItem() { Value = resourcetype.Id.ToString(), Text = resourcetype.Name.ToString() });

            }



            ViewData["ResourceTypes"] = resourceTypeIds;

            return View();

        }



        // POST: Resources/Create

        // To protect from overposting attacks, enable the specific properties you want to bind to, for

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("RegionID,Id,Name,ResourceTypeId,Lng,Lat,Description,URL")] Resource resource)

        {

            if (ModelState.IsValid)

            {

                _context.Add(resource);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }

            return View(resource);

        }



        // GET: Resources/Edit/5

        public async Task<IActionResult> Edit(int? id)

        {

            var resource = await _context.Resource.FindAsync(id);

            if (resource == null)

            {

                return NotFound();

            }





            List<SelectListItem> ids = new List<SelectListItem>();

            List<SelectListItem> resourceTypeIds = new List<SelectListItem>();



            var regions = _context.Region.ToList();



            foreach (var region in regions)
            {
                ids.Add(new SelectListItem() { Value = region.ID.ToString(), Text = region.Name.ToString() });
            }

            ViewData["Numbers"] = ids;

            var resourcetypes = _context.ResourceType.ToList();

            foreach (var resourcetype in resourcetypes)
            {
                resourceTypeIds.Add(new SelectListItem()
                {

                    Value = resourcetype.Id.ToString(),

                    Text = resourcetype.Name.ToString(),

                    Selected = (resourcetype.Id == resource.ResourceTypeId)

                });

            }



            ViewData["ResourceTypes"] = resourceTypeIds;



            if (id == null)

            {

                return NotFound();

            }





            return View(resource);

        }



        // POST: Resources/Edit/5

        // To protect from overposting attacks, enable the specific properties you want to bind to, for

        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("RegionID,Id,Name,ResourceTypeId,Lng,Lat,Description,URL")] Resource resource)

        {





            if (id != resource.Id)

            {

                return NotFound();

            }



            if (ModelState.IsValid)

            {

                try

                {

                    _context.Update(resource);

                    await _context.SaveChangesAsync();

                }

                catch (DbUpdateConcurrencyException)

                {

                    if (!ResourceExists(resource.Id))

                    {

                        return NotFound();

                    }

                    else

                    {

                        throw;

                    }

                }

                return RedirectToAction(nameof(Index));

            }

            return View(resource);

        }



        // GET: Resources/Delete/5

        public async Task<IActionResult> Delete(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }



            var resource = await _context.Resource.FirstOrDefaultAsync(m => m.Id == id);

            if (resource == null)

            {

                return NotFound();

            }



            return View(resource);

        }



        // POST: Resources/Delete/5

        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)

        {

            var resource = await _context.Resource.FindAsync(id);

            _context.Resource.Remove(resource);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }



        private bool ResourceExists(int id)

        {

            return _context.Resource.Any(e => e.Id == id);

        }

    }
}
