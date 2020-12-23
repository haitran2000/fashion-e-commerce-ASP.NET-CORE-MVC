using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Helper
{
    public class Image
    {
        public static async void UploadPicture(int NameId, string NamePicture ,IFormFile ful)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/slider", NameId + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await ful.CopyToAsync(stream);
            }
            NamePicture = NameId + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
        }
    }
}
