using BaseLogic.General;
using MongoDB.Bson.Serialization.Attributes;
using static BaseLogic.General.DeveloperLevel;

namespace BaseLogic.Developer
{
    [BsonIgnoreExtraElements]
    public class PaidDeveloper : IPaidDeveloper
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address PersonalAddress { get; set; }
        public Level ProgramingLevel { get; set; }
        public string ManagerId { get; set; }
        public WorkerKind.Kind WorkerType { get; set; }
        public int Salary { get; set; }
        public int TotalSalary { get; set; }

        internal PaidDeveloper(){}

        public PaidDeveloper(string iD, string firstName, string lastName, Address personalAddress, Level programingLevel, int salary)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            PersonalAddress = personalAddress;
            ProgramingLevel = programingLevel;
            Salary = salary;
            TotalSalary = 0;
            ManagerId = "-1";
            WorkerType = WorkerKind.Kind.PaidDeveloper;
        }
    }
}
