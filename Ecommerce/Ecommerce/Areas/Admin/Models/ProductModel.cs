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
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPicture1 { get; set; }
        public string ProductPicture2 { get; set; }
        public string ProductPicture3 { get; set; }
        public int ProductNumber { get; set; }
        public long ProductPrice { get; set; }
        public long ProductDiscount { get; set; }
        public int ProductSupplierID { get; set; }
        public int ProductBrandID { get; set; }
        public BrandModel Brands { get; set; }
        public SuppliersModel Suppliers { get; set; }
        public int ProductCategoryID { get; set; }
        public CategoryModel Categorys { get; set; }
        public List<OrderDetailsModel> OrderDetails { set; get; }
        public int ProductStatus { get; set; }
        
        
    }
}
