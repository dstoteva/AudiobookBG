namespace AudiobookBG.Web.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.AudioFiles;
    using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult ByBookId(int bookId)
        {
            var viewModel = this.booksService.GetById<AudioFilesListViewModel>(bookId);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CountViews(int audioId)
        {
            await this.audioFilesService.IncrementViews(audioId);
            return this.Ok();
        }
    }
}
