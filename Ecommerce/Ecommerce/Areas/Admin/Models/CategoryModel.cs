using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryKeyWord { get; set; }
        public string CategoryPicture { get; set; }
        public int CategoryStatus { get; set; }
        public List<ProductModel> Products { set; get; }
    }
}
