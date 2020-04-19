namespace AudiobookBG.Web.ViewModels.Home
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class HomeBookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string CoverUrl { get; set; }
    }
}
