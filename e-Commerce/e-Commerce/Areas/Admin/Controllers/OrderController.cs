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
            var dPContext = _context.Orders.Include(o => o.Payment).Include(o => o.User);
            return View(await dPContext.ToListAsync());
        }
        public async Task<IActionResult> Order_Detail(int? id)
        {
            var dPContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(m => m.OrderID == id); ;
            return View(await dPContext.ToListAsync());
        }
        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders
                .Include(o => o.Payment)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        private bool OrderModelExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
