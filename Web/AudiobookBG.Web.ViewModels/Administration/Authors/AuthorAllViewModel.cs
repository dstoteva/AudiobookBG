namespace AudiobookBG.Web.ViewModels.Administration.Authors
{
    using System.Linq;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using AutoMapper;

    public class AuthorAllViewModel : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => string.Join(" ", new[] { this.FirstName, this.MiddleName, this.LastName }
        .Where(n => !string.IsNullOrEmpty(n)));

        public string Url => $"authors/{this.Id}";
    }
}
