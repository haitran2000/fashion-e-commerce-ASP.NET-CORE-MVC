using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Areas.Admin.Models
{
    public class OrdersModel
    {
        public int OrderID { get; set; }
        public long OrderTotalMoney { get; set; }
        public int OrderCarrierID { get; set; }
        public CarriersModel Carriers { get; set; }
        public string OrderShipAdress { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public int OrderCustomerID { get; set; }
        public int OrderPaymentID { get; set; }
        public PaymentModel Payments { get; set; }
        public CustomersModel Customers { get; set; }
        public List<OrderDetailsModel> OrderDetails {set; get;}
        public int OrderStatus { get; set; }
        
    }
}
