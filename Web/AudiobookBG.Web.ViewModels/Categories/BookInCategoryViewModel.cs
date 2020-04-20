namespace AudiobookBG.Web.ViewModels.Categories
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class BookInCategoryViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverUrl { get; set; }

        public string Url => $"books/{this.Id}";
    }
}
