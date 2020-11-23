using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentID { get; set; }
        public string PaymentName { get; set; }
        public int PaymentStatus { get; set; }
    }
}
