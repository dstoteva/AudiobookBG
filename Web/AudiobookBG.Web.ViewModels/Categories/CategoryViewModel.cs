namespace AudiobookBG.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using System.Linq;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using AutoMapper;

    public class CategoryViewModel : IMapFrom<Category>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public IEnumerable<BookInCategoryViewModel> Books { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.Books, y => y.MapFrom(s => s.CategoriesBooks.Select(z => z.Book)));
        }
    }
}
