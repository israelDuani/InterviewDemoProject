using BaseLogic.General;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BaseLogic.Leaders
{
    [BsonIgnoreExtraElements]
    public class PaidTeamLeader : IPaidTeamLeader
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address PersonalAddress { get; set; }
        public List<string> EmployeesId { get; set; }
        public string ManagerId { get; set; }
        public WorkerKind.Kind WorkerType { get; set; }
        public int Salary { get; set; }
        public int TotalSalary { get; set; }

        public PaidTeamLeader(string iD, string firstName, string lastName, Address personalAddress, int salary)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            PersonalAddress = personalAddress;
            EmployeesId = new List<string>();
            Salary = salary;
            TotalSalary = 0;
            ManagerId = "-1";
            WorkerType = WorkerKind.Kind.PaidTeamLeader;
        }
    }
}
