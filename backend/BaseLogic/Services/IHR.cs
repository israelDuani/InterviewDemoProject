using BaseLogic.General;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseLogic.Services
{
    public interface IHR
    {
        Task<List<Worker>> GetBaseWorkersListAsync();
        Task<List<Worker>> GetEmployeesByIdListAsync(List<string> workersIds);
        Task<List<Worker>> GetEmployeesOfMangerAsync(string managerId);
        Task<T> GetWorkerByIdAsync<T>(string workerId);
        Task<BsonDocument> GetWorkerBsonByIdAsync(string id);
        Task AddWorkerToLeaderAsync(string leaderId, string workerId);
        Task RemoveWorkerFromLeaderAsync(string leaderId, string workerId);
        Task FireAsync(string workerId);
        Task HireAsync<T>(string newWorkerId, T worker);
        Task UpdatePersonalAddressAsync(string workerId, Address newAddress);
        Task UpdateProgramingLevelAsync(string workerId, DeveloperLevel.Level newLevel);
    }
}
