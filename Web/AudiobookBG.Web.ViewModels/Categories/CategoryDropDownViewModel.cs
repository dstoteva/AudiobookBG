namespace AudiobookBG.Web.ViewModels.Categories
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
