﻿namespace AudiobookBG.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<string> UploadAsync(IFormFile file, string folderName);
    }
}
