namespace AudiobookBG.Services.Data
{
    public interface IBooksService
    {
        T GetById<T>(int id);
    }
}
