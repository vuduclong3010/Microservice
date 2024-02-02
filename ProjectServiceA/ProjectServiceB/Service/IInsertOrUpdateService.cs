namespace ProjectServiceB.Service
{
    public interface IInsertOrUpdateService
    {
        Task<bool> InsertOrUpdateDatabase(string url);
    }
}
