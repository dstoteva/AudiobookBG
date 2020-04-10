namespace AudiobookBG.Web.ViewModels.Administration.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryInputModel
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
