using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace e_Commerce.Models
{
    public class ShoppingCartModel
    {
        public ShoppingCartModel()
        {
            Amount = 1;
        }
        [Key]
        public int CartID { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserModel User { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductModel Product { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Vui Lòng Nhập Số Lượng")]
        public int Amount { get; set; }
    }
}
