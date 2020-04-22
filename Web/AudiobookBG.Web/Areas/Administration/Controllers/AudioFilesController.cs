namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Administration.AudioFiles;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    public class AudioFilesController : AdministrationController
    {
        private readonly ICloudinaryService cloudinary;
        private readonly IAudioFilesService audioFilesService;

        public AudioFilesController(ICloudinaryService cloudinary, IAudioFilesService audioFilesService)
        {
            this.cloudinary = cloudinary;
            this.audioFilesService = audioFilesService;
        }

        public IActionResult Create(int bookId)
        {
            var viewModel = new AudioFileInputModel
            {
                BookIdFromGetMethod = bookId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AudioFileInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var audioUrl = await this.cloudinary.UploadAsync(input.AudioFile, "audio_files");
            await this.audioFilesService.CreateAsync(input.Title, audioUrl, input.BookId);

            return this.RedirectToAction("ByBookId", new RouteValueDictionary(new { area = "", controller = "AudioFiles", action = "ByBookId", bookId = input.BookId }));
        }
    }
}
