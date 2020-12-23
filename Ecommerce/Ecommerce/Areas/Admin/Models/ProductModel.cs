using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Areas.Admin.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public string Content { get; set; }
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public virtual SupplierModel Supplier { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual BrandModel Brand { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual CategoryModel Category { get; set; }
        public bool Status { get; set; }
    }
}
