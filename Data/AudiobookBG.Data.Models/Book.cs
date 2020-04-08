namespace AudiobookBG.Data.Models
{
    using System.Collections.Generic;

    using AudiobookBG.Data.Common.Models;

    public class Book : BaseDeletableModel<int>
    {
        public Book()
        {
            this.CategoriesBooks = new HashSet<CategoryBook>();
            this.UsersBooks = new HashSet<ApplicationUserBook>();
            this.AuthorsBooks = new HashSet<AuthorBook>();
            this.Comments = new HashSet<Comment>();
            this.AudioFiles = new HashSet<AudioFile>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CoverUrl { get; set; }

        public virtual ICollection<CategoryBook> CategoriesBooks { get; set; }

        public virtual ICollection<ApplicationUserBook> UsersBooks { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<AudioFile> AudioFiles { get; set; }
    }
}
