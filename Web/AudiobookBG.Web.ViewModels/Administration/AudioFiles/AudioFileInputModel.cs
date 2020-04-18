namespace AudiobookBG.Web.ViewModels.Administration.AudioFiles
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class AudioFileInputModel : IMapFrom<AudioFile>
    {
        public string Title { get; set; }

        public IFormFile AudioFile { get; set; }

        public int BookIdFromGetMethod { get; set; }

        public int BookId { get; set; }
    }
}
