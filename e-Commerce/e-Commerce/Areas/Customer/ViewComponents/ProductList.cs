using e_Commerce.Models;
using e_Commerce.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Commerce.Areas.Customer.ViewComponents
{
    [ViewComponent(Name = "Product")]
    public class ProductList : ViewComponent
    {
        private readonly DPContext db;
        public ProductList(DPContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = GetItemsAsync();
            return View(data);
        }
        private List<ProductModel> GetItemsAsync()
        {
            return db.Products.ToList();
        }
    }
}

