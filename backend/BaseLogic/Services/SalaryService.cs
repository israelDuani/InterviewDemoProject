
using System.Threading.Tasks;

namespace BaseLogic.Services
{
    public class SalaryService : ISalary
    {
        private static SalaryService SalaryInstance = null;

        private SalaryService() { }

        public static SalaryService Instance()
        {
            if (SalaryInstance == null)
            {
                SalaryInstance = new SalaryService();
            }
            return SalaryInstance;
        }

        public async Task ChangeSalaryAsync(string workerId, int newSalary)
        {
            await DBCommunicatorService.GetCommunicator().ChangeSalaryAsync(workerId, newSalary);
        }

        public async Task<int> GetTotalPaidSalaryAsync(string workerId)
        {
            return await DBCommunicatorService.GetCommunicator().GetTotalPaidSalaryAsync(workerId);
        }

        public async Task PaySalaryAsync(string workerId)
        {
            await DBCommunicatorService.GetCommunicator().PaySalaryAsync(workerId);
        }
    }
}
