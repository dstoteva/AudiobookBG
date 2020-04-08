namespace AudiobookBG.Web.ViewModels.Administration.Categories
{
    using System.Collections.Generic;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public IEnumerable<BookInCategoryViewModel> CategoriesBooks { get; set; }
    }
}
