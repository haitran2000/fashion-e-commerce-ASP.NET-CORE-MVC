using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class SupplierModel
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public long Adress { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }
    }
}
