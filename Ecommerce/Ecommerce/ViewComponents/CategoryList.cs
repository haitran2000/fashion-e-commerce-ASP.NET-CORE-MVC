using Ecommerce.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Areas.Admin.Models;
namespace Ecommerce.ViewComponents
{
    [ViewComponent(Name = "Category")]
    public class CategoryList : ViewComponent
    {
        private readonly DPContext db;
        public CategoryList(DPContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = GetItemsAsync();
            return View(data);
        }
        private List<CategoryModel> GetItemsAsync()
        {
            return db.Categories.ToList();
        }
    }
}
