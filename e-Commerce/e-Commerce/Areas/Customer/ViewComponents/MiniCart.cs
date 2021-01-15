using e_Commerce.Data;
using e_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Commerce.Areas.Customer.ViewComponents
{
    [ViewComponent(Name = "MiniCart")]
    public class MiniCart : ViewComponent
    {
        private readonly DPContext db;
        public MiniCart(DPContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            var dPContext = db.ShoppingCarts.Include(s => s.Product).Include(s => s.User).ToList();
            return View(dPContext);
        }
    }
}
