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
        public double TotalMoney { get; set; }
        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
