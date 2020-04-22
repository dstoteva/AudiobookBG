namespace AudiobookBG.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int bookId, string content, string userId);
    }
}
