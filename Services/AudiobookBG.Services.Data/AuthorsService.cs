﻿namespace AudiobookBG.Services.Data
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

        public async Task DeleteAsync(int id)
        {
            var author = this.authorsRepository.All().Where(c => c.Id == id).FirstOrDefault();
            author.AuthorsBooks.Clear();

            this.authorsRepository.Delete(author);
            await this.authorsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string firstName, string middleName, string lastName)
        {
            var author = this.authorsRepository.All().Where(c => c.Id == id).FirstOrDefault();

            author.FirstName = firstName;
            author.MiddleName = middleName;
            author.LastName = lastName;

            this.authorsRepository.Update(author);
            await this.authorsRepository.SaveChangesAsync();
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
            var author = this.authorsRepository.All().Where(a => a.Id == id).To<T>().FirstOrDefault();

            return author;
        }
    }
}
