using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Commerce.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        [StringLength(100)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [StringLength(100)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [StringLength(100)]
        [Display(Name = "Hình Sản Phẩm")]
        public string Picture { get; set; }
        [Display(Name = "Sô Lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [StringLength(100)]
        [Display(Name = "Nội Dung")]
        public string Content { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual BrandModel Brand { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual CategoryModel Category { get; set; }
        [StringLength(100)]
        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
    }
}
