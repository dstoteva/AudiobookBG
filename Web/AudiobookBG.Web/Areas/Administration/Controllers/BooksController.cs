namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Administration.Books;
    using Microsoft.AspNetCore.Mvc;

    public class BooksController : AdministrationController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult ById(int id)
        {
            var viewModel = this.booksService.GetById<BookViewModel>(id);

            return this.View(viewModel);
        }
    }
}
