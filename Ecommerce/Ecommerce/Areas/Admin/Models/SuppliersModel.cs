using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class SuppliersModel
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public long SupplierAdress { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierNotes { get; set; }
        public int SupplierLogo { get; set; }
        public int SupplierStatus { get; set; }
    }
}
