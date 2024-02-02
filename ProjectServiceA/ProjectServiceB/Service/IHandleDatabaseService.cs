using Newtonsoft.Json.Linq;

namespace ProjectServiceB.Service
{
    public interface IHandleDatabaseService
    {
        Task<bool> HandleDatabaseTable(string url);
    }
}
