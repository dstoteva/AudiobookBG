namespace AudiobookBG.Web.ViewModels.Administration.Books
{
    using System.Collections.Generic;
    using System.Linq;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using AutoMapper;

    public class BookViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CommentsCount { get; set; }

        public IEnumerable<AuthorInBookViewModel> Authors { get; set; }

        public IEnumerable<CategoryInBookViewModel> Categories { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Book, BookViewModel>()
                .ForMember(x => x.Authors, y => y.MapFrom(ab => ab.AuthorsBooks.Select(b => b.Author)))
                .ForMember(x => x.Categories, y => y.MapFrom(cb => cb.CategoriesBooks.Select(b => b.Category)));
        }
    }
}
