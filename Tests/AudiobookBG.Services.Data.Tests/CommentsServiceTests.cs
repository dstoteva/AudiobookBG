namespace AudiobookBG.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using AudiobookBG.Data;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CommentsServiceTests
    {
        [Fact]
        public async Task CreateCommentShouldReturnTheRightBookId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var bookId = 3;

            await service.Create(bookId, "Comment's content", "userGruidId1");

            var actualBook = await repository.All().FirstOrDefaultAsync();

            Assert.Equal(bookId, actualBook.BookId);
        }

        [Fact]
        public async Task CreateCommentShouldAddThreeComments()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var bookId = 3;

            await service.Create(bookId, "Comment's content", "userGruidId1");
            await service.Create(bookId, "Comment's content", "userGruidId2");
            await service.Create(bookId, "Comment's content", "userGruidId3");

            var actualCommentCount = repository.All().Where(c => c.BookId == bookId).Count();

            Assert.Equal(3, actualCommentCount);
        }

        [Fact]
        public async Task CreateCommentShouldAddTheRightContent()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var bookId = 3;

            var comment1 = new Comment
            {
                UserId = "gudId1",
                BookId = bookId,
                Content = "Comment's content",
            };

            await repository.AddAsync(comment1);
            await repository.SaveChangesAsync();

            var expectedCommentContent = "Comment's content";
            var actualComment = await repository.All().Where(c => c.Id == comment1.Id).FirstOrDefaultAsync();

            Assert.Equal(expectedCommentContent, actualComment.Content);
        }

        [Fact]
        public async Task DeleteCommentDeletesTheRightComment()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var bookId = 3;

            var comment1 = new Comment
            {
                UserId = "gudId1",
                BookId = bookId,
                Content = "content of the comment1.",
            };

            var comment2 = new Comment
            {
                UserId = "gudId2",
                BookId = bookId,
                Content = "content of the comment2.",
            };

            await repository.AddAsync(comment1);
            await repository.AddAsync(comment2);
            await repository.SaveChangesAsync();

            await service.Delete(comment1.Id);

            var comment = await repository.All().Where(c => c.Id == comment1.Id).FirstOrDefaultAsync();

            Assert.Null(comment);
        }

        [Fact]
        public async Task DeleteCommentDeletesOneComment()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var bookId = 3;

            var comment1 = new Comment
            {
                UserId = "gudId1",
                BookId = bookId,
                Content = "content of the comment1.",
            };

            var comment2 = new Comment
            {
                UserId = "gudId2",
                BookId = bookId,
                Content = "content of the comment2.",
            };

            await repository.AddAsync(comment1);
            await repository.AddAsync(comment2);
            await repository.SaveChangesAsync();

            await service.Delete(comment1.Id);

            Assert.Equal(1, repository.All().Count());
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void CommentContentPropertyShouldNotAllowEmptyString(string content)
        {
            CheckContentValidation ccv = new CheckContentValidation();

            var comment = new Comment
            {
                Id = 1,
                UserId = "userGuidId",
                BookId = 1,
                Content = content,
            };

            var errorCount = ccv.Validate(comment).Count();

            Assert.Equal(1, errorCount);
        }

        public class CheckContentValidation
        {
            public IList<ValidationResult> Validate(object model)
            {
                var result = new List<ValidationResult>();

                var validationContext = new ValidationContext(model);
                Validator.TryValidateObject(model, validationContext, result);

                if (model is IValidatableObject)
                {
                    (model as IValidatableObject).Validate(validationContext);
                }

                return result;
            }
        }
    }
}
