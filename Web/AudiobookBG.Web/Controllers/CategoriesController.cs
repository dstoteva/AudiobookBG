namespace AudiobookBG.Web.Controllers
{
    using System.Collections.Generic;

    using AudiobookBG.Services.Data;
    using AudiobookBG.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult ByName(string name)
        {
            return this.View();
        }
    }
}