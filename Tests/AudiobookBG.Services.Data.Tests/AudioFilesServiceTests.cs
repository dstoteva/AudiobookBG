namespace AudiobookBG.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AudiobookBG.Data;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Data.Repositories;
    using AudiobookBG.Services.Mapping;
    using AudiobookBG.Web.ViewModels.AudioFiles;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class AudioFilesServiceTests
    {
        [Fact]
        public async Task CreateAsyncAddsThreeAudioFilesToBook()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<AudioFile>(dbContext);
            var service = new AudioFilesService(repository);

            var bookId = 5;

            await service.CreateAsync("1", "asdafdsfadfsdf1", bookId);
            await service.CreateAsync("2", "asdafdsfadfsdf2", bookId);
            await service.CreateAsync("3", "asdafdsfadfsdf3", bookId);

            var expectedCount = 3;
            var actualCount = repository.All().Count();

            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public async Task CreateAsyncReturnsTheRightId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<AudioFile>(dbContext);
            var service = new AudioFilesService(repository);

            var bookId = 5;

            var audio1 = new AudioFile
            {
                Title = "Audio1",
                Url = "sdsdffsdf1",
                BookId = bookId,
            };

            await repository.AddAsync(audio1);
            await repository.SaveChangesAsync();

            var expectedId = 2;
            var actualId = await service.CreateAsync("Audio2", "asdsad2", bookId);

            Assert.Equal(expectedId, actualId);
        }

        [Fact]
        public async Task DeleteAsyncDeletesOneAudioFile()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<AudioFile>(dbContext);
            var service = new AudioFilesService(repository);

            var bookId = 5;

            var audio1 = new AudioFile
            {
                Title = "Audio1",
                Url = "sdsdffsdf1",
                BookId = bookId,
            };

            var audio2 = new AudioFile
            {
                Title = "Audio2",
                Url = "sdsdffsdf2",
                BookId = bookId,
            };

            var audio3 = new AudioFile
            {
                Title = "Audio3",
                Url = "sdsdffsdf3",
                BookId = bookId,
            };

            await repository.AddAsync(audio1);
            await repository.AddAsync(audio2);
            await repository.AddAsync(audio3);
            await repository.SaveChangesAsync();

            await service.DeleteAsync(audio1.Id);

            var expectedCount = 2;
            var actualCount = repository.All().Count();

            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public async Task DeleteAsyncDeletesTheRightFile()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<AudioFile>(dbContext);
            var service = new AudioFilesService(repository);

            var bookId = 5;

            var audio1 = new AudioFile
            {
                Title = "Audio1",
                Url = "sdsdffsdf1",
                BookId = bookId,
            };

            var audio2 = new AudioFile
            {
                Title = "Audio2",
                Url = "sdsdffsdf2",
                BookId = bookId,
            };

            var audio3 = new AudioFile
            {
                Title = "Audio3",
                Url = "sdsdffsdf3",
                BookId = bookId,
            };

            await repository.AddAsync(audio1);
            await repository.AddAsync(audio2);
            await repository.AddAsync(audio3);
            await repository.SaveChangesAsync();

            await service.DeleteAsync(audio1.Id);

            var actualAudioFile = repository.All().Where(x => x.Id == audio1.Id).FirstOrDefault();

            Assert.Null(actualAudioFile);
        }

        [Fact]
        public async Task EditAsyncChangesTitle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<AudioFile>(dbContext);
            var service = new AudioFilesService(repository);

            var bookId = 5;

            var audio1 = new AudioFile
            {
                Title = "Audio1",
                Url = "sdsdffsdf1",
                BookId = bookId,
            };

            await repository.AddAsync(audio1);
            await repository.SaveChangesAsync();

            await service.EditAsync(audio1.Id, "New Audio Title");

            var expectedTitle = "New Audio Title";

            var actualTitle = repository.All().Where(x => x.Id == audio1.Id).FirstOrDefault();

            Assert.Equal(expectedTitle, actualTitle.Title);
        }

        [Fact]
        public async Task IncrementViewsShouldIncrement()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<AudioFile>(dbContext);
            var service = new AudioFilesService(repository);

            var bookId = 5;

            var audio = new AudioFile
            {
                Title = "Audio",
                Url = "sdsdffsdf",
                BookId = bookId,
            };

            await repository.AddAsync(audio);
            await repository.SaveChangesAsync();

            await service.IncrementViews(audio.Id);
            await service.IncrementViews(audio.Id);
            await service.IncrementViews(audio.Id);
            await service.IncrementViews(audio.Id);

            var expectedViewsCount = 4;

            Assert.Equal(expectedViewsCount, audio.Views);
        }
    }
}
