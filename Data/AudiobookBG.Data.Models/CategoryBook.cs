namespace AudiobookBG.Data.Models
{
    public class CategoryBook
    {
        public CategoryBook()
        {
        }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
