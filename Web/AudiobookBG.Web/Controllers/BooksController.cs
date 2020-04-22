namespace AudiobookBG.Web.Controllers
{
    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Books;
    using Microsoft.AspNetCore.Mvc;

    public class BooksController : BaseController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult ById(int id)
        {
            ///if (!this.User.Identity.IsAuthenticated)
            ///{
            ///    return this.RedirectToAction("Login", "Account", new { area = "Identity" });
            ///}

            var viewModel = this.booksService.GetById<BookViewModel>(id);
            return this.View(viewModel);
        }
    }
}
