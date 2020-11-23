using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Areas.Admin.Models
{
    public class CarriersModel
    {
        public int CarrierID { get; set; }
        public long CarrierName { get; set; }
        public string CarrierStatus { get; set; }
        public List<OrdersModel> Orders { set; get; }
    }
}
