namespace AudiobookBG.Web.ViewModels.Books
{
    using System;

    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CommentInBookViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
