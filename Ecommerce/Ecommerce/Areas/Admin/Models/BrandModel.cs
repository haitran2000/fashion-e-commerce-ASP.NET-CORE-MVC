using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Ecommerce.Areas.Admin.Models
{
    public class BrandModel
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandPicture { get; set; }
        public int BrandDescription { get; set; }
        public int BrandStatus { get; set; }
    }
}
