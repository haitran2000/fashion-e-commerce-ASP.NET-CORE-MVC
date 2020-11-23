using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Areas.Admin.Models
{
    public class OrderDetailsModel
    {
        public int OrderDetailID { get; set; }
        public int OrderDetailProductID { get; set; }
        public int OrderDetailProductName { get; set; }
        public long OrderDetailPrice { get; set; }
        public int OrderDetailNumber { get; set; }
        public string OrderDetailCoupon { get; set; }
        public string OrderDetailState { get; set; }
        public OrdersModel Orders { get; set; }
        public ProductModel Products { get; set; }
        public string OrderDetailColor { get; set; }
        public int OrderStatus { get; set; }
    }
}
