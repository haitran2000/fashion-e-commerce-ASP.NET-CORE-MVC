using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_Commerce.Data;
using e_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using e_Commerce.Helper;
using Microsoft.AspNetCore.Mvc.Filters;

namespace e_Commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminUser)]
    public class CategoryController : Controller
    {
        private readonly DPContext _context;

        public CategoryController(DPContext context)
        {
            _context = context;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.ListCategory = _context.Categories.ToList();
            base.OnActionExecuted(context);
        }
        // GET: Admin/Category
        public async Task<IActionResult> Index(int?id)
        {
            CategoryModel category = null;
            if (id != null)
            {
                category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);
            }

            return View(category);
        }
        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,Name,Description,Status")] CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryModel);
                await _context.SaveChangesAsync();
            }
            return View("Index");
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,Name,Description,Status")] CategoryModel categoryModel)
        {
            if (id != categoryModel.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.CategoryID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            
            }
            return View("Index");
        }
        private bool CategoryModelExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryID == id);
        }
    }
}
