namespace AudiobookBG.Web.ViewModels.Administration.Categories
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using AutoMapper;

    public class BookInCategoryViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverUrl { get; set; }

        public string Url => $"/{this.Id}";
    }
}
