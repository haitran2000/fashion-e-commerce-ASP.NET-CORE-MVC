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
        [Display(Name = "Ngày Đặt Hàng")]
        public DateTime Date { get; set; }
        [Display(Name = "Trạng Thái")]

        public bool Status { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}
