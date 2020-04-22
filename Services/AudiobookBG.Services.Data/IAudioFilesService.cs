namespace AudiobookBG.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAudioFilesService
    {
        T GetById<T>(int id);

        Task<int> CreateAsync(string title, string audioUrl, int bookId);

        IEnumerable<T> GetByBookId<T>(int bookId);

        Task IncrementViews(int audioId);
    }
}
