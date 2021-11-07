using MongoDB.Bson.Serialization.Attributes;

namespace BaseLogic.General
{
    [BsonIgnoreExtraElements]
    public class Worker : IWorker
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ManagerId { get; set; }
        public Address PersonalAddress { get; set; }
        public WorkerKind.Kind WorkerType { get; set; }


        public Worker(string iD, string firstName, string lastName, Address personalAddress, WorkerKind.Kind workerType)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            ManagerId = "-1";
            PersonalAddress = personalAddress;
            WorkerType = workerType;
        }
    }
}
