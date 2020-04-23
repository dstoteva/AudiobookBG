namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBooksService
    {
        T GetById<T>(int id);

        Task<int> CreateAsync(string title, string description, string image, List<int> categories, List<int> authors);

        IEnumerable<T> GetMostViewd<T>();

        Task<string> DeleteAsync(int id);

        Task EditAsync(int id, string title, string description, List<int> categories, List<int> authors, string image);
    }
}
