namespace AudiobookBG.Data.Models
{
    public class ApplicationUserBook
    {
        public ApplicationUserBook()
        {
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
