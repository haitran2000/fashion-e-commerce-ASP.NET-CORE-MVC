using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using static Ecommerce.Helper;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly DPContext _context;

        public AdminController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admin.ToListAsync());
        }

        // GET: Admin/Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModel = await _context.Admin
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (adminModel == null)
            {
                return NotFound();
            }

            return View(adminModel);
        }

        // GET: Admin/Admin/Create
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new AdminModel());
            }
            else
            {
                var adminModel = await _context.Admin.FindAsync(id);
                if (adminModel == null)
                {
                    return NotFound();
                }
                return View(adminModel);
            }    
            
        }

        // POST: Admin/Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("AdminID,AdminEmail,AdminPicture,AdminPassword,AdminName,AdminPhone")] AdminModel adminModel, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", adminModel.AdminID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await ful.CopyToAsync(stream);
                    }
                    adminModel.AdminPicture = adminModel.AdminID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                    _context.Add(adminModel);
                    await _context.SaveChangesAsync();
                }

                else
                {
                    try
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", adminModel.AdminID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await ful.CopyToAsync(stream);
                        }
                        adminModel.AdminPicture = adminModel.AdminID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                        _context.Update(adminModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AdminModelExists(adminModel.AdminID))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _context.Admin.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", adminModel) });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminModel = await _context.Admin
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (adminModel == null)
            {
                return NotFound();
            }

            return View(adminModel);
        }

        // POST: Admin/Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminModel = await _context.Brand.FindAsync(id);
            _context.Brand.Remove(adminModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "Index", _context.Admin.ToList()) });
        }

        private bool AdminModelExists(int id)
        {
            return _context.Admin.Any(e => e.AdminID == id);
        }
    }
}
