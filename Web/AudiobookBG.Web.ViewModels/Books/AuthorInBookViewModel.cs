namespace AudiobookBG.Web.ViewModels.Books
{
    using System.Linq;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AuthorInBookViewModel : IMapFrom<Author>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => string.Join(" ", new[] { this.FirstName, this.MiddleName, this.LastName }
        .Where(n => !string.IsNullOrEmpty(n)));
    }
}
