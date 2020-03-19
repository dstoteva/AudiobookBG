namespace AudiobookBG.Data.Models
{
    using System.Collections.Generic;

    using AudiobookBG.Data.Common.Models;

    public class Author : BaseDeletableModel<int>
    {
        public Author()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
