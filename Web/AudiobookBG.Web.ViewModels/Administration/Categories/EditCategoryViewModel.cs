namespace AudiobookBG.Web.ViewModels.Administration.Categories
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class EditCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
