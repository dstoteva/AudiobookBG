namespace AudiobookBG.Web.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.AudioFiles;
    using Microsoft.AspNetCore.Mvc;

    public class AudioFilesController : BaseController
    {
        private readonly IAudioFilesService audioFilesService;
        private readonly IBooksService booksService;

        public AudioFilesController(IAudioFilesService audioFilesService, IBooksService booksService)
        {
            this.audioFilesService = audioFilesService;
            this.booksService = booksService;
        }

        public IActionResult ByBookId(int bookId)
        {
            var viewModel = this.booksService.GetById<AudioFilesListViewModel>(bookId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CountViews(int audioId)
        {
            await this.audioFilesService.IncrementViews(audioId);
            return this.Ok();
        }
    }
}
