using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPicture1 { get; set; }
        public string ProductPicture2 { get; set; }
        public string ProductPicture3 { get; set; }
        public int ProductNumber { get; set; }
        public long ProductPrice { get; set; }
        public long ProductDiscount { get; set; }
        public string ProductSupplierID { get; set; }
        public string ProductCategoryID { get; set; }
        public int ProductStatus { get; set; }
        public virtual CategoryModel CategoryModel { get; set; }
        public virtual SuppliersModel SuppliersModel { get; set; }
    }
}
