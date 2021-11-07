using BaseLogic.Developer;
using BaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasicLogic.Tests
{
    public class SalaryTests
    {
        //void PaySalary(string workerId);
        //void ChangeSalary(string workerId, int newSalary);
        //long GetTotalPaidSalary(string workerId);

        [Fact]
        public async Task PaySalaryTest() //V
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(16);
            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var expected = newDev.Salary*2;
            await SalaryService.Instance().PaySalaryAsync(newDev.ID);
            await SalaryService.Instance().PaySalaryAsync(newDev.ID);

            var result = await SalaryService.Instance().GetTotalPaidSalaryAsync(newDev.ID);
            await HRService.Instance().FireAsync(newDev.ID);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(8500)]
        public async Task ChangeSalaryTest(int newSalary)
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(17);
            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var expected = newSalary;
            await SalaryService.Instance().ChangeSalaryAsync(newDev.ID, newSalary);

            var dbDev = await HRService.Instance().GetWorkerByIdAsync<PaidDeveloper>(newDev.ID);
            await HRService.Instance().FireAsync(newDev.ID);

            Assert.Equal(expected, dbDev.Salary);
        }

        [Fact]
        public async Task GetTotalPaidSalaryTest()
        {
            var newDev = WorkersFactory.GenerateNewPaidDeveloper(18);
            newDev.TotalSalary = 600;
            await HRService.Instance().HireAsync(newDev.ID, newDev);

            var expected = 600;

            var result = await SalaryService.Instance().GetTotalPaidSalaryAsync(newDev.ID);
            await HRService.Instance().FireAsync(newDev.ID);

            Assert.Equal(expected, result);
        }

    }
}
