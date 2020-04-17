namespace AudiobookBG.Web.ViewModels.Administration.Books
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
