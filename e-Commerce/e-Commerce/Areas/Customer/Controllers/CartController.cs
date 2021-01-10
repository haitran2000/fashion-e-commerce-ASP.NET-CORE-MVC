using e_Commerce.Data;
using e_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_Commerce.Areas.Customer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace e_Commerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly DPContext _db;
        public List<ShoppingCartModel> ShoppingCartItems { get; set; }
        public CartController(DPContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var dPContext = _db.ShoppingCarts.Include(s => s.Product).Include(s => s.User);
            return View(await dPContext.ToListAsync());
        }
    }
}
