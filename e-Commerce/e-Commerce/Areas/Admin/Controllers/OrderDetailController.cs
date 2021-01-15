using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_Commerce.Data;
using e_Commerce.Models;

namespace e_Commerce.Areas.Admin.Controllers
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
            var dPContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/OrderDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailModel = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetailModel == null)
            {
                return NotFound();
            }

            return View(orderDetailModel);
        }

        // GET: Admin/OrderDetail/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "StreetAddress");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return View();
        }

        // POST: Admin/OrderDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailID,OrderID,ProductID,Quantity,Status")] OrderDetailModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetailModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "StreetAddress", orderDetailModel.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", orderDetailModel.ProductID);
            return View(orderDetailModel);
        }

        // GET: Admin/OrderDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailModel = await _context.OrderDetails.FindAsync(id);
            if (orderDetailModel == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "StreetAddress", orderDetailModel.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", orderDetailModel.ProductID);
            return View(orderDetailModel);
        }

        // POST: Admin/OrderDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailID,OrderID,ProductID,Quantity,Status")] OrderDetailModel orderDetailModel)
        {
            if (id != orderDetailModel.OrderDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetailModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailModelExists(orderDetailModel.OrderDetailID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "StreetAddress", orderDetailModel.OrderID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", orderDetailModel.ProductID);
            return View(orderDetailModel);
        }

        // GET: Admin/OrderDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetailModel = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetailModel == null)
            {
                return NotFound();
            }

            return View(orderDetailModel);
        }

        // POST: Admin/OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetailModel = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetailModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailModelExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }
    }
}
