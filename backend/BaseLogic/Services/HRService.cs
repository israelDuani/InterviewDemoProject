using BaseLogic.DB;
using BaseLogic.General;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseLogic.Services
{
    public class HRService : IHR
    {
        private static HRService HRInstance = null;

        private HRService() { }

        public static HRService Instance()
        {
            if(HRInstance == null)
            {
                HRInstance = new HRService();
            }
            return HRInstance;
        }

        public async Task AddWorkerToLeaderAsync(string leaderId, string workerId)
        {
            await DBCommunicatorService.GetCommunicator().AddWorkerToLeaderAsync(leaderId, workerId);
        }

        public async Task FireAsync(string workerId)
        {
            await MongoCommunicator.Instance().FireAsync(workerId);
        }

        public async Task<List<Worker>> GetBaseWorkersListAsync()
        {
            return await DBCommunicatorService.GetCommunicator().GetBaseWorkersListAsync();
        }

        public async Task<List<Worker>> GetEmployeesByIdListAsync(List<string> workersIds)
        {
            return await DBCommunicatorService.GetCommunicator().GetEmployeesByIdListAsync(workersIds);
        }

        public async Task<List<Worker>> GetEmployeesOfMangerAsync(string managerId)
        {
            return await DBCommunicatorService.GetCommunicator().GetEmployeesOfMangerAsync(managerId);
        }

        public async Task<BsonDocument> GetWorkerBsonByIdAsync(string id)
        {
            return await DBCommunicatorService.GetCommunicator().GetWorkerBsonByIdAsync(id);
        }

        public async Task<T> GetWorkerByIdAsync<T>(string workerId)
        {
            return await DBCommunicatorService.GetCommunicator().GetWorkerByIdAsync<T>(workerId);
        }

        public async Task HireAsync<T>(string newWorkerId, T worker)
        {
            await DBCommunicatorService.GetCommunicator().HireAsync(newWorkerId, worker);
        }

        public async Task RemoveWorkerFromLeaderAsync(string leaderId, string workerId)
        {
            await DBCommunicatorService.GetCommunicator().RemoveWorkerFromLeaderAsync(leaderId, workerId);
        }

        public async Task UpdatePersonalAddressAsync(string workerId, Address newAddress)
        {
            await DBCommunicatorService.GetCommunicator().UpdatePersonalAddressAsync(workerId, newAddress);
        }

        public async Task UpdateProgramingLevelAsync(string workerId, DeveloperLevel.Level newLevel)
        {
            await DBCommunicatorService.GetCommunicator().UpdateProgramingLevelAsync(workerId, newLevel);
        }
    }
}
