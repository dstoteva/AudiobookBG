namespace AudiobookBG.Web.ViewModels.Administration.Categories
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CategoryAllViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public int CategoriesBooksCount { get; set; }

        public string Url => $"/{this.Name.Replace(' ', '-')}";
    }
}
