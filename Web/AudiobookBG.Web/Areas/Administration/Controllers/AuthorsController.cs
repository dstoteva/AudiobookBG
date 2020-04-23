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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.authorsService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.authorsService.GetById<EditAuthorViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAuthorViewModel viewModel)
        {
            await this.authorsService.EditAsync(viewModel.Id, viewModel.FirstName, viewModel.MiddleName, viewModel.LastName);
            return this.RedirectToAction("Index");
        }
    }
}
