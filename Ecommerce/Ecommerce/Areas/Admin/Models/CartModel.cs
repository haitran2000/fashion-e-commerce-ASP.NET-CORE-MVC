using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Areas.Admin.Models
{
    public class CartModel
    {
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
