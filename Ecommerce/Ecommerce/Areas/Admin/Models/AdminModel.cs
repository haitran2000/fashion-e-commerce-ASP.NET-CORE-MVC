using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Areas.Admin.Models
{
    public class AdminModel
    {
        public int AdminID { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPicture { get; set; }
        public string AdminPassword { get; set; }
        public string AdminName { get; set; }
        public string AdminPhone { get; set; }
    }
}
