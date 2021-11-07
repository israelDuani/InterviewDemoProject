using MongoDB.Bson.Serialization.Attributes;

namespace BaseLogic.General
{
    [BsonIgnoreExtraElements]
    class PaidWorker : IPaidWorker
    {
        public string ID { get; set; }
        public int Salary { get; set; }
        public int TotalSalary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ManagerId { get; set; }
        public Address PersonalAddress { get; set; }
        public WorkerKind.Kind WorkerType { get; set; }
    }
}
