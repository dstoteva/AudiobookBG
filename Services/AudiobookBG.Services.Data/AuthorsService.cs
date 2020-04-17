namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Common.Repositories;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class AuthorsService : IAuthorsService
    {
        private readonly IDeletableEntityRepository<Author> authorsRepository;

        public AuthorsService(IDeletableEntityRepository<Author> authorsRepository)
        {
            this.authorsRepository = authorsRepository;
        }

        public async Task<int> CreateAsync(string firstName, string lastName, string middleName)
        {
            if (this.authorsRepository.All().Any(c => c.FirstName == firstName && c.LastName == lastName))
            {
                return -1;
            }

            var author = new Author
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
            };

            await this.authorsRepository.AddAsync(author);
            await this.authorsRepository.SaveChangesAsync();
            return author.Id;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Author> query = this.authorsRepository.All().OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
