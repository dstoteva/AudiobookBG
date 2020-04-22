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
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var imageUrl = await this.cloudinary.UploadAsync(input.Image, "book_covers");
            var bookId = await this.booksService.CreateAsync(input.Title, input.Description, imageUrl, input.SelectedCategories, input.SelectedAuthors);

            return this.RedirectToAction("ById", "Books", new { id = bookId, Area = "" });
        }
    }
}
