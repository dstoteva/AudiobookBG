namespace AudiobookBG.Web.Controllers
{
    using System.Diagnostics;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels;
    using AudiobookBG.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IBooksService booksService;

        public HomeController(IBooksService booksService)
        {
            this.booksService = booksService;
        }

        public IActionResult Index()
        {
            var books = this.booksService.GetMostViewd<HomeBookViewModel>();

            var viewModel = new HomeViewModel
            {
                Books = books,
            };
            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
