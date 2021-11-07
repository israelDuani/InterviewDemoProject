using BaseLogic.Developer;
using BaseLogic.General;
using BaseLogic.Leaders;
using BaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasicLogic.Tests
{
    public class HRTests
    {
        //--List<Worker> GetBaseWorkersList();
        //--List<Worker> GetEmployeesOfManger(List<string> workersIds);
        //--T GetWorkerById<T>(string workerId);
        //--BsonDocument GetWorkerBsonById(string id);
        //--void AddWorkerToLeader(ILeader leader, IWorker worker);
        //--void RemoveWorkerFromLeader(ILeader leader, IWorker worker);
        //void Fire(string workerId);
        //void Hire<T>(string newWorkerId, T worker);
        //void UpdatePersonalAddress(string workerId, Address newAddress);
        //void UpdateProgramingLevel(string workerId, DeveloperLevel.Level newLevel);

        [Fact]
        public async Task GetBaseWorkersListTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(1);
            var newManager = WorkersFactory.GenerateNewPaidManager(2);
            int expected = 2;

            await HRService.Instance().HireAsync(newDev.ID, newDev);
            await HRService.Instance().HireAsync(newManager.ID, newManager);

            List<Worker> result = await HRService.Instance().GetBaseWorkersListAsync();

            await HRService.Instance().FireAsync(newDev.ID);
            await HRService.Instance().FireAsync(newManager.ID);
            
            Assert.Equal(expected, result.Count);
        }

        [Fact]
        public async Task GetEmployeesOfMangerTest() 
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(3);
            var newTL = WorkersFactory.GenerateNewPaidTeamLeader(4);
            var newManager = WorkersFactory.GenerateNewPaidManager(5);
            var expected = 2;

            newManager.EmployeesId.Add(newDev.ID);
            newManager.EmployeesId.Add(newTL.ID);

            await HRService.Instance().HireAsync(newDev.ID, newDev);
            await HRService.Instance().HireAsync(newTL.ID, newTL);
            await HRService.Instance().HireAsync(newManager.ID, newManager);

            var result = await HRService.Instance().GetEmployeesOfMangerAsync(newManager.ID);

            await HRService.Instance().FireAsync(newDev.ID);
            await HRService.Instance().FireAsync(newTL.ID);
            await HRService.Instance().FireAsync(newManager.ID);

            Assert.Equal(expected, result.Count);
        }

        [Fact]
        public async Task GetWorkerByIdTest() //V
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(6);
            await HRService.Instance().HireAsync(newDev.ID, newDev);
            var expected = "6";

            var result = await HRService.Instance().GetWorkerByIdAsync<PaidDeveloper>(newDev.ID);

            await HRService.Instance().FireAsync(newDev.ID);

            Assert.NotNull(result);
            Assert.Equal(expected, result.ID);
        }

        [Fact]
        public async Task GetWorkerBsonByIdTest() //V
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(7);
            await HRService.Instance().HireAsync(newDev.ID, newDev);
            var expected = "7";

            var result = await HRService.Instance().GetWorkerBsonByIdAsync(newDev.ID);

            await HRService.Instance().FireAsync(newDev.ID);

            Assert.NotNull(result);
            Assert.Equal(expected, result.GetValue("ID"));
        }

        [Fact]
        public async Task AddWorkerToLeaderTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(8);
            var newManager = WorkersFactory.GenerateNewPaidManager(9);

            await HRService.Instance().HireAsync(newDev.ID, newDev);
            await HRService.Instance().HireAsync(newManager.ID, newManager);


            await HRService.Instance().AddWorkerToLeaderAsync(newManager.ID, newDev.ID);

            var expectedWorkerId = "8";
            var expectedManagerId = "9";


            var dbWorker = await HRService.Instance().GetWorkerByIdAsync<Worker>(newDev.ID);
            var dbLeader = await HRService.Instance().GetWorkerByIdAsync<Leader>(newManager.ID);

            await HRService.Instance().FireAsync(newDev.ID);
            await HRService.Instance().FireAsync(newManager.ID);

            Assert.NotNull(dbWorker);
            Assert.NotNull(dbLeader);
            Assert.Equal(expectedManagerId, dbWorker.ManagerId);
            Assert.Equal(expectedWorkerId, dbLeader.EmployeesId[0]);
        }

        [Fact]
        public async Task RemoveWorkerFromLeaderTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(10);
            var newManager = WorkersFactory.GenerateNewPaidManager(11);
            newManager.EmployeesId.Add("10");
            newDev.ManagerId = "11";

            await HRService.Instance().HireAsync(newDev.ID, newDev);
            await HRService.Instance().HireAsync(newManager.ID, newManager);

            await HRService.Instance().RemoveWorkerFromLeaderAsync(newManager.ID, newDev.ID);
            var expectedManagerId = "-1";
            List<string> expectedWorkerId = null;


            var dbWorker = await HRService.Instance().GetWorkerByIdAsync<Worker>(newDev.ID);
            var dbLeader = await HRService.Instance().GetWorkerByIdAsync<Leader>(newDev.ID);

            await HRService.Instance().FireAsync(newDev.ID);
            await HRService.Instance().FireAsync(newManager.ID);

            Assert.NotNull(dbWorker);
            Assert.NotNull(dbLeader);
            Assert.Equal(expectedManagerId, dbWorker.ManagerId);
            Assert.Equal(expectedWorkerId, dbLeader.EmployeesId);
        }

        [Fact]
        public async Task FireTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(12);

            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var beforeFire = await HRService.Instance().GetWorkerBsonByIdAsync(newDev.ID);
            Assert.NotNull(beforeFire);

            await HRService.Instance().FireAsync(newDev.ID);

            var afterFire = await HRService.Instance().GetWorkerBsonByIdAsync(newDev.ID);
            Assert.Null(afterFire);
        }

        [Fact]
        public async Task HireTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(13);

            var beforeHire = await HRService.Instance().GetWorkerBsonByIdAsync(newDev.ID);
            Assert.Null(beforeHire);

            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var afterHire = await HRService.Instance().GetWorkerBsonByIdAsync(newDev.ID);
            await HRService.Instance().FireAsync(newDev.ID);

            Assert.NotNull(afterHire);
        }

        [Fact]
        public async Task UpdatePersonalAddressTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(14);
            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var expectedAddress = AddressFactory.GenerateAddressForType(14, "newAddressAfterTest");
            await HRService.Instance().UpdatePersonalAddressAsync(newDev.ID, expectedAddress);

            var dbDev = await HRService.Instance().GetWorkerByIdAsync<PaidDeveloper>(newDev.ID);
            await HRService.Instance().FireAsync(newDev.ID);

            Assert.Equal(expectedAddress,dbDev.PersonalAddress);
        }

        [Fact]
        public async Task UpdateProgramingLevel() //V
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(15);
            newDev.ProgramingLevel = DeveloperLevel.Level.Junior;
            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var expected = DeveloperLevel.Level.Mid;
            await HRService.Instance().UpdateProgramingLevelAsync(newDev.ID, expected);


            var dbDev = await HRService.Instance().GetWorkerByIdAsync<PaidDeveloper>(newDev.ID);
            await HRService.Instance().FireAsync(newDev.ID);

            Assert.Equal(expected, dbDev.ProgramingLevel);
        }
    }
}
