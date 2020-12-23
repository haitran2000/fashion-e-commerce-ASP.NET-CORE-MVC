using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string KeyWord { get; set; }
        public string Picture { get; set; }
        public bool Status { get; set; }
    }
}
