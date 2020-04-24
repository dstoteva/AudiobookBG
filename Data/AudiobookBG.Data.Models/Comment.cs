namespace AudiobookBG.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AudiobookBG.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
        }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
