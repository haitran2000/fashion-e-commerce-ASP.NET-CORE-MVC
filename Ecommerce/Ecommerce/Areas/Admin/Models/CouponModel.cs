using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class CouponModel
    {
        [Key]
        public int CouponID { get; set; }
        public string CouponName { get; set; }
        public string CouponCode { get; set; }
        public int CouponStatus { get; set; }
    }
}
