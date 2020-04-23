namespace AudiobookBG.Web.ViewModels.Administration.Books
{
    using System.Collections.Generic;
    using System.Linq;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;

    public class EditBookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public IEnumerable<AuthorDropDownViewModel> Authors { get; set; }

        public IEnumerable<CategoryDropDownViewModel> Categories { get; set; }

        public List<int> SelectedCategories { get; set; } = new List<int>();

        public List<int> SelectedAuthors { get; set; } = new List<int>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, EditBookViewModel>()
                .ForMember(x => x.Authors, y => y.MapFrom(ab => ab.AuthorsBooks.Select(b => b.Author)))
                .ForMember(x => x.Categories, y => y.MapFrom(cb => cb.CategoriesBooks.Select(b => b.Category)));
        }
    }
}
