using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Areas.Admin.Models
{
    public class SliderModel
    {
        [Key]
        public int SliderID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
    }
}
