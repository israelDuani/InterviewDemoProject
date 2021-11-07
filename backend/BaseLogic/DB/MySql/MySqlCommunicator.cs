using BaseLogic.General;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseLogic.DB
{
    public class MySqlCommunicator : IDBCommunicator
    {
        private static MySqlCommunicator MySqlInstance = null;
        private static MongoBasicActions MySqlBase = null;
        private MySqlCommunicator() { }

        public static MySqlCommunicator Instance()
        {
            if (MySqlInstance == null)
            {
                MySqlInstance = new MySqlCommunicator();
                //MySqlBase = MongoBasicActions.Instance();
            }
            return MySqlInstance;
        }

        public async Task AddWorkerToLeaderAsync(string leaderId, string workerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task ChangeSalaryAsync(string workerId, int newSalary)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task FireAsync(string workerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task<List<Worker>> GetBaseWorkersListAsync()
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task<List<Worker>> GetEmployeesByIdListAsync(List<string> workersIds)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task<List<Worker>> GetEmployeesOfMangerAsync(string managerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalPaidSalaryAsync(string workerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task<BsonDocument> GetWorkerBsonByIdAsync(string id)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task<T> GetWorkerByIdAsync<T>(string workerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task HireAsync<T>(string newWorkerId, T worker)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task PaySalaryAsync(string workerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task RemoveWorkerFromLeaderAsync(string leaderId, string workerId)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task UpdatePersonalAddressAsync(string workerId, Address newAddress)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }

        public async Task UpdateProgramingLevelAsync(string workerId, DeveloperLevel.Level newLevel)
        {
            await Task.FromResult(0);
            throw new NotImplementedException();
        }
    }
}
