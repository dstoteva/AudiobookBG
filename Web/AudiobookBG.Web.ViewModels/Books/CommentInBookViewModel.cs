namespace AudiobookBG.Web.ViewModels.Books
{
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using System;

    public class CommentInBookViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
