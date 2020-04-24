namespace AudiobookBG.Web.Controllers
{
    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Books;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        [Authorize]
        public IActionResult ById(int id)
        {
            var viewModel = this.booksService.GetById<BookViewModel>(id);
            if (viewModel == null)
            {
                return this.View("NotFound");
            }

            return this.View(viewModel);
        }
    }
}
