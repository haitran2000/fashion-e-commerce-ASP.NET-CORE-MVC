using Ecommerce.Areas.Admin.Data;
using Ecommerce.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ViewComponents
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

