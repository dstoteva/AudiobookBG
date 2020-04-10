namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AudiobookBG.Data.Models;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(string name);

        T GetByName<T>(string name);
    }
}
