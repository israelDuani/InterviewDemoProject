using BaseLogic.General;
using System.Collections.Generic;

namespace BaseLogic.Leaders
{
    public interface ILeader : IWorker
    {
        List<string> EmployeesId { get; set; }
    }
}
