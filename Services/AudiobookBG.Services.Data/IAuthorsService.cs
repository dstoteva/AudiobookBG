namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> CreateAsync(string firstName, string lastName, string middleName);

        T GetById<T>(int id);

        Task DeleteAsync(int id);
    }
}
