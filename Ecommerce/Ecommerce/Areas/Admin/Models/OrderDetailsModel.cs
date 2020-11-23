using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class OrderDetailsModel
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderDetailOrderID { get; set; }
        public long OrderDetailProductID { get; set; }
        public string OrderDetailProductName { get; set; }
        public long OrderDetailProductPrice { get; set; }
        public string OrderDetailCoupon { get; set; }
        public string OrderDetailState { get; set; }
        public int OrderDetailStatus { get; set; }
        public virtual OrdersModel OrdersModel { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
