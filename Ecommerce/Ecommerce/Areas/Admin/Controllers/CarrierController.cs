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
            return View(await _context.Carrier.ToListAsync());
        }

        // GET: Admin/Carrier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriersModel = await _context.Carrier
                .FirstOrDefaultAsync(m => m.CarrierID == id);
            if (carriersModel == null)
            {
                return NotFound();
            }

            return View(carriersModel);
        }

        // GET: Admin/Carrier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Carrier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarrierID,CarrierName,CarrierStatus")] CarriersModel carriersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carriersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carriersModel);
        }

        // GET: Admin/Carrier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriersModel = await _context.Carrier.FindAsync(id);
            if (carriersModel == null)
            {
                return NotFound();
            }
            return View(carriersModel);
        }

        // POST: Admin/Carrier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarrierID,CarrierName,CarrierStatus")] CarriersModel carriersModel)
        {
            if (id != carriersModel.CarrierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carriersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarriersModelExists(carriersModel.CarrierID))
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
            return View(carriersModel);
        }

        // GET: Admin/Carrier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carriersModel = await _context.Carrier
                .FirstOrDefaultAsync(m => m.CarrierID == id);
            if (carriersModel == null)
            {
                return NotFound();
            }

            return View(carriersModel);
        }

        // POST: Admin/Carrier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carriersModel = await _context.Carrier.FindAsync(id);
            _context.Carrier.Remove(carriersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarriersModelExists(int id)
        {
            return _context.Carrier.Any(e => e.CarrierID == id);
        }
    }
}
