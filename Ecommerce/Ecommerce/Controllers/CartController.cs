using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;
using Ecommerce.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private DPContext _db;
        public CartController(DPContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.ProductID * item.Quantity);
            return View();
        }
        private int isExist(int id)
        {
            List<CartModel> cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
            for(int i=0;i<cart.Count;i++)
            {
                if(cart[i].Product.ProductID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public ProductModel getDetailProduct(int id)
        {
            var product = _db.Products.Find(id);
            return product;
        }
        public IActionResult Buy (int id)
        {

            if(SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session,"cart")==null)
            {
                var product = getDetailProduct(id);
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { Product=product, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            else
            {
                List<CartModel> cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index!=-1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartModel { Product = _db.Products.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            List<CartModel> cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

    }
}
