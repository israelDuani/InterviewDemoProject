
namespace BaseLogic.General
{
    public interface IWorker
    {
        string ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string ManagerId { get; set; }
        Address PersonalAddress { get; set; }
        WorkerKind.Kind WorkerType { get; set; }
    }
}
