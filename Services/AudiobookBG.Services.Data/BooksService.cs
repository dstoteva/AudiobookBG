namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Common.Repositories;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class BooksService : IBooksService
    {
        private readonly IDeletableEntityRepository<Book> booksRepository;
        private readonly IDeletableEntityRepository<Comment> commentsRepository;
        private readonly IDeletableEntityRepository<AudioFile> audioFilesRepository;

        public BooksService(IDeletableEntityRepository<Book> booksRepository, IDeletableEntityRepository<Comment> commentsRepository, IDeletableEntityRepository<AudioFile> audioFilesRepository)
        {
            this.booksRepository = booksRepository;
            this.commentsRepository = commentsRepository;
            this.audioFilesRepository = audioFilesRepository;
        }

        public async Task<int> CreateAsync(string title, string description, string image, List<int> categories, List<int> authors)
        {
            var book = new Book
            {
                Title = title,
                Description = description,
                CoverUrl = image,
            };

            authors.ForEach(x => book.AuthorsBooks.Add(new AuthorBook() { AuthorId = x, BookId = book.Id }));
            categories.ForEach(x => book.CategoriesBooks.Add(new CategoryBook() { CategoryId = x, BookId = book.Id }));

            await this.booksRepository.AddAsync(book);
            await this.booksRepository.SaveChangesAsync();

            return book.Id;
        }

        public T GetById<T>(int id)
        {
            var book = this.booksRepository.All().Where(b => b.Id == id)
                .To<T>()
                .FirstOrDefault();

            return book;
        }

        public IEnumerable<T> GetMostViewd<T>()
        {
            IQueryable<Book> books = this.booksRepository.All().OrderByDescending(b => b.AudioFiles.Sum(af => af.Views))
                .Take(5);

            return books.To<T>().ToList();
        }

        public async Task<string> DeleteAsync(int id)
        {
            var book = this.booksRepository.All().Where(c => c.Id == id).FirstOrDefault();
            var categoryName = book.CategoriesBooks.Select(b => b.Category.Name).FirstOrDefault();

            var comments = this.commentsRepository.All().Where(c => c.BookId == book.Id);
            var audioFiles = this.audioFilesRepository.All().Where(af => af.BookId == book.Id);

            foreach (var item in comments)
            {
                this.commentsRepository.Delete(item);
            }

            foreach (var item in audioFiles)
            {
                this.audioFilesRepository.Delete(item);
            }

            book.AuthorsBooks.Clear();
            book.CategoriesBooks.Clear();

            this.booksRepository.Delete(book);
            await this.booksRepository.SaveChangesAsync();

            return categoryName;
        }
    }
}
