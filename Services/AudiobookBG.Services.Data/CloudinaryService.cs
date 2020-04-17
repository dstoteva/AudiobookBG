using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace AudiobookBG.Services.Data
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadAsync(IFormFile file, string folderName)
        {
            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            UploadResult result = null;

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = folderName,
                    File = new FileDescription(file.Name, destinationStream),
                };

                result = await this.cloudinary.UploadAsync(uploadParams);
            }

            return result?.SecureUri.AbsoluteUri;
        }
    }
}
