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
using static Ecommerce.Helper; 

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly DPContext _context;

        public BrandController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Brand
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brand.ToListAsync());
        }

        // GET: Admin/Brand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandModel = await _context.Brand
                .FirstOrDefaultAsync(m => m.BrandID == id);
            if (brandModel == null)
            {
                return NotFound();
            }

            return View(brandModel);
        }

        // GET: Admin/Brand/AddOrDeit
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new BrandModel());
            }
            else
            {
                var brandModel = await _context.Brand.FindAsync(id);
                if (brandModel == null)
                {
                    return NotFound();
                }
                return View(brandModel);
            }    
        }

        // POST: Admin/Brand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id,[Bind("BrandID,BrandName,BrandPicture,BrandDescription,BrandStatus")] BrandModel brandModel, IFormFile ful)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/brand", brandModel.BrandID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    brandModel.BrandPicture = brandModel.BrandID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                    _context.Add(brandModel);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    try
                    {
                        _context.Update(brandModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BrandModelExists(brandModel.BrandID))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Brand.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", brandModel) });
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandModel = await _context.Brand
                .FirstOrDefaultAsync(m => m.BrandID == id);
            if (brandModel == null)
            {
                return NotFound();
            }

            return View(brandModel);
        }

        // POST: Admin/Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandModel = await _context.Brand.FindAsync(id);
            _context.Brand.Remove(brandModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Brand.ToList()) });
        }

        private bool BrandModelExists(int id)
        {
            return _context.Brand.Any(e => e.BrandID == id);
        }
    }
}
