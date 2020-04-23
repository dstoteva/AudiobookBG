namespace AudiobookBG.Web.ViewModels.Books
{
    using System.Collections.Generic;
    using System.Linq;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using AutoMapper;

    public class BookViewModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentInBookViewModel> Comments { get; set; }

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
