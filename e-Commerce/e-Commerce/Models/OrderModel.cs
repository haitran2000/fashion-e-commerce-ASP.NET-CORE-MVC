using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Commerce.Models
{

    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }
       
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserModel User { get; set; }
        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual PaymentModel Payment { get; set; }
        [Required]
        [Display(Name = "Tổng Tiền")]
        public decimal TotalMoney { get; set; }
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Địa Chỉ")]
        [StringLength(100)]
        [Display(Name = "Địa Chỉ")]
        public string StreetAddress { get; set; }
        [StringLength(100)]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }
        [StringLength(50)]
        [Display(Name = "QUận/Huyện")]
        public string District { get; set; }
        [StringLength(50)]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }
        public string PhoneNumber { get; set; }
        [Display(Name = "Ngày Đặt Hàng")]
        public DateTime Date { get; set; }
        [Display(Name = "Trạng Thái")]

        public bool Status { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}
