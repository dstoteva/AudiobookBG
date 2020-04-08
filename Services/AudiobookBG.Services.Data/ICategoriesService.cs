namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<bool> AddAsync(Category category);

        T GetByName<T>(string name);
    }
}
