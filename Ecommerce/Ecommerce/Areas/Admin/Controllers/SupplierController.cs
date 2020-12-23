using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly DPContext _context;

        public SupplierController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Supplier
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suppliers.ToListAsync());
        }

        // GET: Admin/Supplier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierModel = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplierModel == null)
            {
                return NotFound();
            }

            return View(supplierModel);
        }

        // GET: Admin/Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierID,Name,Adress,Phone,Notes,Logo,Status")] SupplierModel supplierModel, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierModel);
                //Image.UploadPicture(sliderModel.SliderID, sliderModel.Picture, ful);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/supplier", supplierModel.SupplierID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                supplierModel.Logo = supplierModel.SupplierID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                _context.Add(supplierModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierModel);
        }

        // GET: Admin/Supplier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierModel = await _context.Suppliers.FindAsync(id);
            if (supplierModel == null)
            {
                return NotFound();
            }
            return View(supplierModel);
        }

        // POST: Admin/Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierID,Name,Adress,Phone,Notes,Logo,Status")] SupplierModel supplierModel, IFormFile ful)
        {
            if (id != supplierModel.SupplierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(supplierModel);
                    //Image.UploadPicture(sliderModel.SliderID, sliderModel.Picture, ful);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/supplier", supplierModel.SupplierID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    supplierModel.Logo = supplierModel.SupplierID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                    _context.Add(supplierModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierModelExists(supplierModel.SupplierID))
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
            return View(supplierModel);
        }

        // GET: Admin/Supplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierModel = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplierModel == null)
            {
                return NotFound();
            }

            return View(supplierModel);
        }

        // POST: Admin/Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierModel = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplierModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierModelExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierID == id);
        }
    }
}
