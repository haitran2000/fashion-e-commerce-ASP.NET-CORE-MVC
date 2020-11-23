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
    public class OrderController : Controller
    {
        private readonly DPContext _context;

        public OrderController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index()
        {
            var dPContext = _context.Order.Include(o => o.Carriers).Include(o => o.Customers).Include(o => o.Payments);
            return View(await dPContext.ToListAsync());
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.Order
                .Include(o => o.Carriers)
                .Include(o => o.Customers)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return View(ordersModel);
        }

        // GET: Admin/Order/Create
        public IActionResult Create()
        {
            ViewData["OrderCarrierID"] = new SelectList(_context.Carrier, "CarrierID", "CarrierID");
            ViewData["OrderCustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
            ViewData["OrderPaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentID");
            return View();
        }

        // POST: Admin/Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderTotalMoney,OrderCarrierID,OrderShipAdress,OrderCity,OrderState,OrderCustomerID,OrderPaymentID,OrderStatus")] OrdersModel ordersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderCarrierID"] = new SelectList(_context.Carrier, "CarrierID", "CarrierID", ordersModel.OrderCarrierID);
            ViewData["OrderCustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", ordersModel.OrderCustomerID);
            ViewData["OrderPaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentID", ordersModel.OrderPaymentID);
            return View(ordersModel);
        }

        // GET: Admin/Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.Order.FindAsync(id);
            if (ordersModel == null)
            {
                return NotFound();
            }
            ViewData["OrderCarrierID"] = new SelectList(_context.Carrier, "CarrierID", "CarrierID", ordersModel.OrderCarrierID);
            ViewData["OrderCustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", ordersModel.OrderCustomerID);
            ViewData["OrderPaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentID", ordersModel.OrderPaymentID);
            return View(ordersModel);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderTotalMoney,OrderCarrierID,OrderShipAdress,OrderCity,OrderState,OrderCustomerID,OrderPaymentID,OrderStatus")] OrdersModel ordersModel)
        {
            if (id != ordersModel.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersModelExists(ordersModel.OrderID))
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
            ViewData["OrderCarrierID"] = new SelectList(_context.Carrier, "CarrierID", "CarrierID", ordersModel.OrderCarrierID);
            ViewData["OrderCustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", ordersModel.OrderCustomerID);
            ViewData["OrderPaymentID"] = new SelectList(_context.Payment, "PaymentID", "PaymentID", ordersModel.OrderPaymentID);
            return View(ordersModel);
        }

        // GET: Admin/Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersModel = await _context.Order
                .Include(o => o.Carriers)
                .Include(o => o.Customers)
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return View(ordersModel);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordersModel = await _context.Order.FindAsync(id);
            _context.Order.Remove(ordersModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersModelExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}
