namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetById<T>(int id);

        Task<int> CreateAsync(string firstName, string lastName, string middleName);

        Task DeleteAsync(int id);

        Task EditAsync(int id, string firstName, string middleName, string lastName);
    }
}
