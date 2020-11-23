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
    public class CouponController : Controller
    {
        private readonly DPContext _context;

        public CouponController(DPContext context)
        {
            _context = context;
        }

        // GET: Admin/Coupon
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupon.ToListAsync());
        }

        // GET: Admin/Coupon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponModel = await _context.Coupon
                .FirstOrDefaultAsync(m => m.CouponID == id);
            if (couponModel == null)
            {
                return NotFound();
            }

            return View(couponModel);
        }

        // GET: Admin/Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Coupon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CouponID,CouponName,CouponCode,CouponStatus")] CouponModel couponModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(couponModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(couponModel);
        }

        // GET: Admin/Coupon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponModel = await _context.Coupon.FindAsync(id);
            if (couponModel == null)
            {
                return NotFound();
            }
            return View(couponModel);
        }

        // POST: Admin/Coupon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CouponID,CouponName,CouponCode,CouponStatus")] CouponModel couponModel)
        {
            if (id != couponModel.CouponID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(couponModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponModelExists(couponModel.CouponID))
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
            return View(couponModel);
        }

        // GET: Admin/Coupon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponModel = await _context.Coupon
                .FirstOrDefaultAsync(m => m.CouponID == id);
            if (couponModel == null)
            {
                return NotFound();
            }

            return View(couponModel);
        }

        // POST: Admin/Coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var couponModel = await _context.Coupon.FindAsync(id);
            _context.Coupon.Remove(couponModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponModelExists(int id)
        {
            return _context.Coupon.Any(e => e.CouponID == id);
        }
    }
}
