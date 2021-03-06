﻿namespace AudiobookBG.Web.Controllers
{
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
            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                if (viewModel == null)
                {
                    return this.View("NotFound");
                }
            }

            return this.View(viewModel);
        }
    }
}
