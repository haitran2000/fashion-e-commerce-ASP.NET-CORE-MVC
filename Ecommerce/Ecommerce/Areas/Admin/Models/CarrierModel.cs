using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Ecommerce.Areas.Admin.Models
{
    public class CarrierModel
    {
        [Key]
        public int CarrierID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
