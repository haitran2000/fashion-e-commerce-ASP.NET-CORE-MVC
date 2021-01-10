using e_Commerce.Data;
using e_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace e_Commerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly DPContext _db;

        public HomeController(DPContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.Include(s => s.Category).ToListAsync();
            return View(products);
        }

        public void AddToCart(ProductModel product,UserModel user)
        {
            var shoppingCartItem =
                    _db.ShoppingCarts.SingleOrDefault(
                        s => s.ProductId == product.ProductID && s.UserID == user.Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartModel
                {
                    UserID = user.Id,
                    ProductId=product.ProductID,
                    Product = product,
                    User=user,
                    Amount = 1
                };

                _db.ShoppingCarts.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _db.SaveChanges();
        }
        public RedirectToActionResult Add(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ProductModel selectedProduct = _db.Products.FirstOrDefault(p => p.ProductID == productId);
            UserModel selectedUser = _db.User.FirstOrDefault(p => p.Id == userId);

            if (selectedProduct != null && selectedUser != null)
            {
                AddToCart(selectedProduct, selectedUser);
            }

            return RedirectToAction("Index");
        }
    }
}
