
namespace BaseLogic.General
{
    public interface IPaidWorker : IWorker
    {
        int Salary { get; set; }
        int TotalSalary { get; set; }
    }
}
