using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Areas.Admin.Models
{
    public class OrderDetailModel
    {
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual OrderModel Order { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual ProductModel Product { get; set; }
        public int ProductName { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
