using e_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Commerce.Areas.Customer.ViewModel
{
    public class CartViewModel
    {
        public List<ShoppingCartModel> listCart { get; set; }
    }
}
