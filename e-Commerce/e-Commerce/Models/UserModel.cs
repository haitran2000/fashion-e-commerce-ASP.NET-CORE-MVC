using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace e_Commerce.Models
{
    public class UserModel : IdentityUser
    {
        [StringLength(100)]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui Lòng Nhập Địa Chỉ")]
        [StringLength(100)]
        [Display(Name = "Địa Chỉ")]
        public string StreetAddress { get; set; }
        [StringLength(100)]
        [Display(Name = "Thành Phố")]
        public string City { get; set; }
        [StringLength(50)]
        [Display(Name = "QUận/Huyện")]
        public string District { get; set; }
        [StringLength(50)]
        [Display(Name = "Phường/Xã")]
        public string Ward { get; set; }
    }
}
