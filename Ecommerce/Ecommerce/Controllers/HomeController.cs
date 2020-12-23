using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;
using Ecommerce.Helper;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly DPContext _db;
        public HomeController(DPContext db)
        {
            this._db = db;
        }

        public ActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            return View();
        }

        //GET ALL PRODUCT
        public List<ProductModel> getAllProduct()
        {
            return _db.Products.ToList();
        }

        //GET DETAIL PRODUCT
        public ProductModel getDetailProduct(int id)
        {
            var product = _db.Products.Find(id);
            return product;
        }
        //ADD CART
        public IActionResult addCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart == null)
            {
                var product = getDetailProduct(id);
                List<CartModel> listCart = new List<CartModel>()
               {
                   new CartModel
                   {
                       Product = product,
                       Quantity = 1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.ProductID == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new CartModel
                    {
                        Product = getDetailProduct(id),
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                // var cart2 = HttpContext.Session.GetString("cart");//get key cart
                //  return Json(cart2);
            }

            return RedirectToAction(nameof(Index));

        }
        public IActionResult ListCart()
        {
            var cart = HttpContext.Session.GetString("cart");//get key cart
            if (cart != null)
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult updateCart(int id, int quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);
                if (quantity > 0)
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.ProductID == id)
                        {
                            dataCart[i].Quantity = quantity;
                        }
                    }


                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
                var cart2 = HttpContext.Session.GetString("cart");
                return Ok(quantity);
            }
            return BadRequest();

        }
        public IActionResult deleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<CartModel> dataCart = JsonConvert.DeserializeObject<List<CartModel>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.ProductID == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                return RedirectToAction(nameof(ListCart));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
