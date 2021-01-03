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
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool Status { get; set; }
    }
}
