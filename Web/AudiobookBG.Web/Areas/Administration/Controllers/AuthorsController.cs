namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Administration.Authors;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorsController : AdministrationController
    {
        private readonly IAuthorsService authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            this.authorsService = authorsService;
        }

        public IActionResult Index()
        {
            var viewModel = new AllViewModel
            {
                All = this.authorsService.GetAll<AuthorAllViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.authorsService.CreateAsync(input.FirstName, input.LastName, input.MiddleName);
            return this.RedirectToAction("Index");
        }
    }
}
