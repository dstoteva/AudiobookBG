namespace AudiobookBG.Data.Models
{
    using System.Collections.Generic;

    using AudiobookBG.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.CategoriesBooks = new HashSet<CategoryBook>();
        }

        public string Name { get; set; }

        public virtual ICollection<CategoryBook> CategoriesBooks { get; set; }
    }
}
