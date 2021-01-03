using e_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Commerce.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<CategoryModel> CategoryList { get; set; }

        public ProductModel Products { get; set; }
        public IEnumerable<BrandModel> BrandList { get; set; }
    }
}
