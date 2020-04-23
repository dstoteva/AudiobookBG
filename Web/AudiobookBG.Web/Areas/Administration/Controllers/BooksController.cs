namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Administration.Books;
    using Microsoft.AspNetCore.Mvc;

    public class BooksController : AdministrationController
    {
        private readonly IBooksService booksService;
        private readonly ICategoriesService categoriesService;
        private readonly IAuthorsService authorsService;
        private readonly ICloudinaryService cloudinary;

        public BooksController(IBooksService booksService, ICategoriesService categoriesService, IAuthorsService authorsService, ICloudinaryService cloudinary)
        {
            this.booksService = booksService;
            this.categoriesService = categoriesService;
            this.authorsService = authorsService;
            this.cloudinary = cloudinary;
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new BookCreateInputModel() { Categories = categories, };

            var authors = this.authorsService.GetAll<AuthorDropDownViewModel>();
            viewModel.Authors = authors;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateInputModel input)
        {
            var imageUrl = await this.cloudinary.UploadAsync(input.Image, "book_covers");
            var bookId = await this.booksService.CreateAsync(input.Title, input.Description, imageUrl, input.SelectedCategories, input.SelectedAuthors);

            return this.RedirectToAction("ById", "Books", new { id = bookId, Area = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryName = await this.booksService.DeleteAsync(id);
            return this.RedirectToAction("ByName", "Categories", new { name = categoryName, Area = "" });
        }

        public IActionResult Edit(int id)
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var authors = this.authorsService.GetAll<AuthorDropDownViewModel>();

            var viewModel = this.booksService.GetById<EditBookViewModel>(id);
            viewModel.Categories = categories;
            viewModel.Authors = authors;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel viewModel)
        {
            var imageUrl = "";
            if (viewModel.Image != null)
            {
                imageUrl = await this.cloudinary.UploadAsync(viewModel.Image, "book_covers");
            }

            await this.booksService.EditAsync(viewModel.Id, viewModel.Title, viewModel.Description, viewModel.SelectedCategories, viewModel.SelectedAuthors, imageUrl);
            return this.RedirectToAction("ById", "Books", new { id = viewModel.Id, Area = ""});
        }
    }
}
