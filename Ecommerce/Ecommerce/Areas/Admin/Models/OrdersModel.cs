using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Ecommerce.Areas.Admin.Models
{
    public class OrdersModel
    {
        [Key]
        public int OrderID { get; set; }
        public long OrderTotalMoney { get; set; }
        public string OrderShipName { get; set; }
        public string OrderShipAdress { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderUserID { get; set; }
        public int OrderStatus { get; set; }
    }
}
