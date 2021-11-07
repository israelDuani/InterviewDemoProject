using BaseLogic.General;
using BaseLogic.Leaders;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseLogic.DB
{
    public class MongoCommunicator : IDBCommunicator
    {
        private static MongoCommunicator MongoInstance = null;
        private static MongoBasicActions MongoBase = null;
        private MongoCommunicator() { }

        public static MongoCommunicator Instance()
        {
            if (MongoInstance == null)
            {
                MongoInstance = new MongoCommunicator();
                MongoBase = MongoBasicActions.Instance();
            }
            return MongoInstance;
        }

        public async Task<List<Worker>> GetBaseWorkersListAsync()
        {
            return await MongoBase.GetAllObjectsAsync<Worker>();
        }

        public async Task<List<Worker>> GetEmployeesByIdListAsync(List<string> workersIds)
        {
            var workersList = new List<Worker>();
            foreach (string workerId in workersIds)
            {
                var pulledWorker = await GetWorkerByIdAsync<Worker>(workerId);
                workersList.Add(pulledWorker);
            }

            return workersList;
        }

        public async Task<List<Worker>> GetEmployeesOfMangerAsync(string managerId)
        {
            var leader = await GetWorkerByIdAsync<Leader>(managerId);
            var result = await GetEmployeesByIdListAsync(leader.EmployeesId);

            return result;
        }

        public async Task<T> GetWorkerByIdAsync<T>(string workerId) 
        {
            return await MongoBase.GetObjectByIdAsync<T>(workerId);
        }

        public async Task<BsonDocument> GetWorkerBsonByIdAsync(string id)
        {
            return await MongoBase.GetBsonByIdAsync(id);
        }

        public async Task AddWorkerToLeaderAsync(string leaderId, string workerId)
        {
            Leader dbLeader = await GetWorkerByIdAsync<Leader>(leaderId);
            Worker dbWorker = await GetWorkerByIdAsync<Worker>(workerId);

            dbLeader.EmployeesId.Add(workerId);
            dbWorker.ManagerId = leaderId;

            await MongoBase.SetFieldAsync(dbLeader.ID, DBFieldNames.EmployeesId, dbLeader.EmployeesId);
            await MongoBase .SetFieldAsync(dbWorker.ID, DBFieldNames.ManagerId, dbLeader.ID);
        }

        public async Task RemoveWorkerFromLeaderAsync(string leaderId, string workerId)
        {
            Leader dbLeader = await GetWorkerByIdAsync<Leader>(leaderId);
            Worker dbWorker = await GetWorkerByIdAsync<Worker>(workerId);
            
            dbLeader.EmployeesId.Remove(workerId);
            dbWorker.ManagerId = "-1";

            await MongoBase.SetFieldAsync(dbLeader.ID, DBFieldNames.EmployeesId, dbLeader.EmployeesId);
            await MongoBase .SetFieldAsync(dbWorker.ID, DBFieldNames.ManagerId, "-1");
        }


        public async Task FireAsync(string workerId)
        {
            await MongoBase.DeleteWorkerByIdAsync(workerId);
        }

        public async Task<int> GetTotalPaidSalaryAsync(string workerId)
        {
            var paidWorker = await GetWorkerByIdAsync<PaidWorker>(workerId);
            return paidWorker.TotalSalary;
        }

        public async Task HireAsync<T>(string newWorkerId,T worker)
        {
            await MongoBase.AddNewObjectAsync(newWorkerId,worker);
        }

        public async Task PaySalaryAsync(string workerId)
        {
            var paidWorker = await GetWorkerByIdAsync<PaidWorker>(workerId);
            await MongoBase.AddToNumericFieldAsync(workerId, DBFieldNames.TotalSalary, paidWorker.Salary);
        }

        public async Task ChangeSalaryAsync(string workerId, int newSalary)
        {
            await MongoBase.SetFieldAsync(workerId, DBFieldNames.Salary, newSalary);
        }

        public async Task UpdatePersonalAddressAsync(string workerId, Address newAddress)
        {
            await MongoBase.SetFieldAsync(workerId, DBFieldNames.PersonalAddress, newAddress);
        }

        public async Task UpdateProgramingLevelAsync(string workerId, DeveloperLevel.Level newLevel)
        {
            await MongoBase.SetFieldAsync(workerId, DBFieldNames.ProgramingLevel, newLevel);
        }
    }
}
