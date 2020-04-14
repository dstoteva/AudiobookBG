namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Administration.Books;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class BooksController : AdministrationController
    {
        private readonly IBooksService booksService;
        private readonly ICategoriesService categoriesService;

        public BooksController(IBooksService booksService, ICategoriesService categoriesService)
        {
            this.booksService = booksService;
            this.categoriesService = categoriesService;
        }

        public IActionResult ById(int id)
        {
            var viewModel = this.booksService.GetById<BookViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new BookCreateInputModel() { Categories = categories, };

            // Add AuthorsService;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string txt)
        {
            var categoriesIds = JsonConvert.DeserializeObject<BookCreateInputModel>(txt);
            if (!this.ModelState.IsValid)
            {
                // return this.View(input);
            }

            return this.RedirectToAction(nameof(this.ById));
            // , new { id = bookId }
        }
    }
}
