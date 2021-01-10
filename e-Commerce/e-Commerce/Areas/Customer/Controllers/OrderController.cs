using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_Commerce.Data;
using e_Commerce.Models;
using System.Security.Claims;

namespace e_Commerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly DPContext _context;

        public OrderController(DPContext context)
        {
            _context = context;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public decimal Total()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var total = _context.ShoppingCarts.Where(c => c.UserID == userId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;
        }
        public void CheckoutCart(OrderModel order)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var listCart = _context.ShoppingCarts.Where(s => s.UserID == userId).ToList();
            order = new OrderModel
            {
                UserID = userId,
                PaymentID = 1,
                TotalMoney = Total(),
                Date = DateTime.Now,
                Status = true,
            };
            order.OrderDetails = new List<OrderDetailModel>();
            foreach (var cart in listCart)
            {
                var orderDetail = new OrderDetailModel
                {
                   ProductID=cart.ProductId,
                   Quantity=cart.Amount,
                   Status=true,
                };

                order.OrderDetails.Add(orderDetail);
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public void ClearCart()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItems = _context
                .ShoppingCarts
                .Where(s => s.UserID == userId);

            _context.ShoppingCarts.RemoveRange(cartItems);

            _context.SaveChanges();
        }
        [HttpPost]
        public IActionResult Checkout(OrderModel order)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CartItem =
                     _context.ShoppingCarts.Where(
                         s => s.UserID == userId).ToList();

            if (CartItem.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            else
            {
                CheckoutCart(order);
                ClearCart()
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
