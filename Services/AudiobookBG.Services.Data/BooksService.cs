namespace AudiobookBG.Services.Data
{
    using System.Linq;

    using AudiobookBG.Data.Common.Repositories;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class BooksService : IBooksService
    {
        private readonly IDeletableEntityRepository<Book> booksRepository;

        public BooksService(IDeletableEntityRepository<Book> booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        public T GetById<T>(int id)
        {
            var book = this.booksRepository.All().Where(b => b.Id == id)
                .To<T>()
                .FirstOrDefault();

            return book;
        }
    }
}
