using e_Commerce.Data;
using e_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(Request.QueryString.Value.IndexOf("s_name")<0)
            {
                ViewBag.ListProduct = _db.Products.ToList();
            }
            base.OnActionExecuted(context);
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.Include(s => s.Category).ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> ShopList(string?s_name,int loai_sp)
        {
            ProductModel product = null;
            if(s_name!=null&&loai_sp==null)
            {
                    ViewBag.ListProduct = (from p in _db.Products where p.Name.Contains(s_name) orderby p.CategoryID descending select p).ToList();             
            }
            if (s_name == null && loai_sp != null)
            {
                    ViewBag.ListProduct = (from p in _db.Products where p.CategoryID == loai_sp orderby p.CategoryID descending select p).ToList();
            }
            else
            {
                ViewBag.ListProduct= (from p in _db.Products select p).ToList();
            }
            
            return View(product);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _db.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
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
