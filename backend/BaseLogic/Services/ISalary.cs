
using System.Threading.Tasks;

namespace BaseLogic.Services
{
    public interface ISalary
    {
        Task PaySalaryAsync(string workerId);
        Task ChangeSalaryAsync(string workerId, int newSalary);
        Task<int> GetTotalPaidSalaryAsync(string workerId);
    }
}
