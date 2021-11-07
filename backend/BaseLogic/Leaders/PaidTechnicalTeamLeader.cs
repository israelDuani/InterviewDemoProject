using BaseLogic.General;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BaseLogic.Leaders
{
    [BsonIgnoreExtraElements]
    public class PaidTechnicalTeamLeader : IPaidTechnicalTeamLeader
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address PersonalAddress { get; set; }
        public DeveloperLevel.Level ProgramingLevel { get; set; }
        public List<string> EmployeesId { get; set; }
        public string ManagerId { get; set; }
        public WorkerKind.Kind WorkerType { get; set; }
        public int Salary { get; set; }
        public int TotalSalary { get; set; }

        public PaidTechnicalTeamLeader(string iD, string firstName, string lastName, Address personalAddress,
                                       DeveloperLevel.Level programingLevel, int salary)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            PersonalAddress = personalAddress;
            ProgramingLevel = programingLevel;
            EmployeesId = new List<string>();
            Salary = salary;
            TotalSalary = 0;
            ManagerId = "-1";
            WorkerType = WorkerKind.Kind.PaidTechnicalTeamLeader;
        }
    }
}
