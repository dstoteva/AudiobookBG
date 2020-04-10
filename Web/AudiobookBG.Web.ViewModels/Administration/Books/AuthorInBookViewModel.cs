namespace AudiobookBG.Web.ViewModels.Administration.Books
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AuthorInBookViewModel : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Url => $"authors/{this.Id}";
    }
}
