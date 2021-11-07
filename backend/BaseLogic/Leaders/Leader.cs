using BaseLogic.General;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BaseLogic.Leaders
{
    [BsonIgnoreExtraElements]
    public class Leader : ILeader
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address PersonalAddress { get; set; }
        public List<string> EmployeesId { get; set; }
        public string ManagerId { get; set; }
        public WorkerKind.Kind WorkerType { get; set; }

        public Leader(string iD, string firstName, string lastName, Address personalAddress, List<string> employeesId, WorkerKind.Kind workerType)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            PersonalAddress = personalAddress;
            EmployeesId = employeesId;
            ManagerId = "-1";
            WorkerType = workerType;
        }
    }
}
