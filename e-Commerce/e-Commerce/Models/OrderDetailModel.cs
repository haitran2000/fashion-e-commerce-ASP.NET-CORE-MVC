﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Commerce.Models
{
    public class OrderDetailModel
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual OrderModel Order { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
