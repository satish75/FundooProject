using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public  class ImageCloudinary
    {
        public string ImgaeUrl(IFormFile formFile)
        {
            var name = formFile.Name;
            Account myAccount = new Account("fundoocloude", "744549157642415", "zyjmdQQIiZSamFSTunSTlGaZpfQ");
            Cloudinary _cloudinary = new Cloudinary(myAccount);
            var stream = formFile.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.Uri.ToString();
        }
    }
}
