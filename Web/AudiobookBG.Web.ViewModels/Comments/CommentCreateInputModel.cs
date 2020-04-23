namespace AudiobookBG.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class CommentCreateInputModel
    {
        public int BookId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
