using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Areas.Admin.Models
{ 

    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }
        public long TotalMoney { get; set; }
        public int CarrierID { get; set; }
        [ForeignKey("CarrierID")]
        public virtual CarrierModel Carrier { get; set; }
        public int? ShippingID { get; set; }
        [ForeignKey("ShippingID")]
        public virtual ShippingModel Shipping { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual CustomerModel Customer { get; set; }
        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual PaymentModel Payment { get; set; }
        
        public bool Status { get; set; }
    }
}
