using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace e_Commerce.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(100)]
        [Display(Name = "Tên Loại Hàng")]
        public string Name { get; set; }
        [StringLength(1000)]
        [Display(Name = "Thông Tin")]
        public string Description { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
    }
}
