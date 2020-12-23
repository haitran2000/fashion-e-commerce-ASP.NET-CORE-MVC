using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Areas.Admin.Models
{
    public class ShippingModel
    {
        [Key]
        public int ShippingID { set; get; }
        public string Name { set; get; }
        public int CustomerID { set; get; }
        [ForeignKey("CustomerID")]
        public virtual CustomerModel Customer { get; set; }
        public string Address { set; get; }
        public string Phone { set; get; }
        
    }
}
