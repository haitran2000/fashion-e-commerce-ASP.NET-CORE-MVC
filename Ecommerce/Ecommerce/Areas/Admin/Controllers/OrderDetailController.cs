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
    public class OrderDetailController : Controller
    {
        private readonly DPContext _context;

        public OrderDetailController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/OrderDetail
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.OrderDetail.Include(o => o.Orders).Include(o => o.Products);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/OrderDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsModel = await _context.OrderDetail
                .Include(o => o.Orders)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetailsModel == null)
            {
                return NotFound();
            }

            return View(orderDetailsModel);
        }

        // GET: Admin/OrderDetail/Create
        public IActionResult Create()
        {
            ViewData["OrderDetailID"] = new SelectList(_context.Order, "OrderID", "OrderID");
            ViewData["OrderDetailProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return View();
        }

        // POST: Admin/OrderDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailID,OrderDetailProductID,OrderDetailProductName,OrderDetailPrice,OrderDetailNumber,OrderDetailCoupon,OrderDetailState,OrderDetailColor,OrderStatus")] OrderDetailsModel orderDetailsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetailsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderDetailID"] = new SelectList(_context.Order, "OrderID", "OrderID", orderDetailsModel.OrderDetailID);
            ViewData["OrderDetailProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderDetailsModel.OrderDetailProductID);
            return View(orderDetailsModel);
        }

        // GET: Admin/OrderDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsModel = await _context.OrderDetail.FindAsync(id);
            if (orderDetailsModel == null)
            {
                return NotFound();
            }
            ViewData["OrderDetailID"] = new SelectList(_context.Order, "OrderID", "OrderID", orderDetailsModel.OrderDetailID);
            ViewData["OrderDetailProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderDetailsModel.OrderDetailProductID);
            return View(orderDetailsModel);
        }

        // POST: Admin/OrderDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailID,OrderDetailProductID,OrderDetailProductName,OrderDetailPrice,OrderDetailNumber,OrderDetailCoupon,OrderDetailState,OrderDetailColor,OrderStatus")] OrderDetailsModel orderDetailsModel)
        {
            if (id != orderDetailsModel.OrderDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsModelExists(orderDetailsModel.OrderDetailID))
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
            ViewData["OrderDetailID"] = new SelectList(_context.Order, "OrderID", "OrderID", orderDetailsModel.OrderDetailID);
            ViewData["OrderDetailProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderDetailsModel.OrderDetailProductID);
            return View(orderDetailsModel);
        }

        // GET: Admin/OrderDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailsModel = await _context.OrderDetail
                .Include(o => o.Orders)
                .Include(o => o.Products)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetailsModel == null)
            {
                return NotFound();
            }

            return View(orderDetailsModel);
        }

        // POST: Admin/OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetailsModel = await _context.OrderDetail.FindAsync(id);
            _context.OrderDetail.Remove(orderDetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsModelExists(int id)
        {
            return _context.OrderDetail.Any(e => e.OrderDetailID == id);
        }
    }
}
