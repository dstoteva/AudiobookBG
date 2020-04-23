namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(string name);

        T GetByName<T>(string name);

        Task DeleteAsync(int id);

        T GetById<T>(int id);

        Task EditAsync(int id, string name);
    }
}
