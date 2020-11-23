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
    public class ProductController : Controller
    {
        private readonly DPContext _context;

        public ProductController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Product
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.Product.Include(p => p.Brands).Include(p => p.Categorys).Include(p => p.Suppliers);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .Include(p => p.Brands)
                .Include(p => p.Categorys)
                .Include(p => p.Suppliers)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
            ViewData["ProductBrandID"] = new SelectList(_context.Brand, "BrandID", "BrandID");
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryID");
            ViewData["ProductSupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductDescription,ProductPicture1,ProductPicture2,ProductPicture3,ProductNumber,ProductPrice,ProductDiscount,ProductSupplierID,ProductBrandID,ProductCategoryID,ProductStatus")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductBrandID"] = new SelectList(_context.Brand, "BrandID", "BrandID", productModel.ProductBrandID);
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryID", productModel.ProductCategoryID);
            ViewData["ProductSupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID", productModel.ProductSupplierID);
            return View(productModel);
        }

        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            ViewData["ProductBrandID"] = new SelectList(_context.Brand, "BrandID", "BrandID", productModel.ProductBrandID);
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryID", productModel.ProductCategoryID);
            ViewData["ProductSupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID", productModel.ProductSupplierID);
            return View(productModel);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductDescription,ProductPicture1,ProductPicture2,ProductPicture3,ProductNumber,ProductPrice,ProductDiscount,ProductSupplierID,ProductBrandID,ProductCategoryID,ProductStatus")] ProductModel productModel)
        {
            if (id != productModel.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.ProductID))
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
            ViewData["ProductBrandID"] = new SelectList(_context.Brand, "BrandID", "BrandID", productModel.ProductBrandID);
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryID", productModel.ProductCategoryID);
            ViewData["ProductSupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID", productModel.ProductSupplierID);
            return View(productModel);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .Include(p => p.Brands)
                .Include(p => p.Categorys)
                .Include(p => p.Suppliers)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.Product.FindAsync(id);
            _context.Product.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
