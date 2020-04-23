namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Common.Repositories;
    using AudiobookBG.Data.Models;
    using AudiobookBG.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<int> CreateAsync(string name)
        {
            if (this.categoriesRepository.All().Any(c => c.Name == name))
            {
                return -1;
            }

            var category = new Category
            {
                Name = name,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
            return category.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var category = this.categoriesRepository.All().Where(c => c.Id == id).FirstOrDefault();

            foreach (var item in category.CategoriesBooks)
            {
                category.CategoriesBooks.Clear();
            }

            //this.categoriesRepository.Update(category);
            this.categoriesRepository.Delete(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> query = this.categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var category = this.categoriesRepository.All().Where(c => c.Name == name)
                .To<T>()
                .FirstOrDefault();

            return category;
        }
    }
}
