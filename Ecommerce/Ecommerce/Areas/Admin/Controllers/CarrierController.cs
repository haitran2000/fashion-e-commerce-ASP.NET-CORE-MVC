using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarrierController : Controller
    {
        private readonly DPContext _context;

        public CarrierController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Carrier
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carriers.ToListAsync());
        }

        // GET: Admin/Carrier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierModel = await _context.Carriers
                .FirstOrDefaultAsync(m => m.CarrierID == id);
            if (carrierModel == null)
            {
                return NotFound();
            }

            return View(carrierModel);
        }

        // GET: Admin/Carrier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Carrier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarrierID,Name,Status")] CarrierModel carrierModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrierModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrierModel);
        }

        // GET: Admin/Carrier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierModel = await _context.Carriers.FindAsync(id);
            if (carrierModel == null)
            {
                return NotFound();
            }
            return View(carrierModel);
        }

        // POST: Admin/Carrier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarrierID,Name,Status")] CarrierModel carrierModel)
        {
            if (id != carrierModel.CarrierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrierModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierModelExists(carrierModel.CarrierID))
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
            return View(carrierModel);
        }

        // GET: Admin/Carrier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierModel = await _context.Carriers
                .FirstOrDefaultAsync(m => m.CarrierID == id);
            if (carrierModel == null)
            {
                return NotFound();
            }

            return View(carrierModel);
        }

        // POST: Admin/Carrier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierModel = await _context.Carriers.FindAsync(id);
            _context.Carriers.Remove(carrierModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierModelExists(int id)
        {
            return _context.Carriers.Any(e => e.CarrierID == id);
        }
    }
}
