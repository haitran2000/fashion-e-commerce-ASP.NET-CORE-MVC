using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace e_Commerce.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentID { get; set; }
        [StringLength(100)]
        [Display(Name = "Tên Phương Thức")]
        public string Name { get; set; }
        [StringLength(100)]
        [Display(Name = "Logo")]
        public string Logo { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
    }
}
