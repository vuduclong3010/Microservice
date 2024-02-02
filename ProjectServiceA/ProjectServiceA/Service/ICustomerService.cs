using ProjectServiceA.Dto;
using ProjectServiceA.Models;

namespace ProjectServiceA.Service
{
    public interface ICustomerService
    {
        Task<Dictionary<string, object>> GetDatabase();
    }
}
