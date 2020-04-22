namespace AudiobookBG.Services.Data
{
    using System.Threading.Tasks;

    using AudiobookBG.Data.Common.Repositories;
    using AudiobookBG.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int bookId, string content, string userId)
        {
            var comment = new Comment
            {
                Content = content,
                BookId = bookId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
