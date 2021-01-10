using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_Commerce.Models
{
    public class BrandModel
    {
        [Key]
        public int BrandID { get; set; }
        [StringLength(100)]
        [Display(Name = "Tên Nhãn Hàng")]
        public string Name { get; set; }
        [StringLength(100)]
        [Display(Name = "Logo Nhãn Hàng")]
        public string Picture { get; set; }
        [StringLength(1000)]
        [Display(Name = "Thông Tin")]
        public string Description { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
    }
}
