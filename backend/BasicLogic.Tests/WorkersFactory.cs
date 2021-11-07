using BaseLogic.Developer;
using BaseLogic.General;
using BaseLogic.Leaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseLogic.General.DeveloperLevel;

namespace BasicLogic.Tests
{
    public static class WorkersFactory
    {

        public static Worker GenerateNewWorker(int id)
        {
            string typeName = "baseWorker";
            Address addr = AddressFactory.GenerateAddressForType(id, typeName);
            Worker output = new Worker($"{id}", $"{typeName}FirstName{id}", $"{typeName}LastName{id}", addr, WorkerKind.Kind.Worker); ;
            return output;
        }

        public static PaidDeveloper GenerateNewPaidDeveloper(int id)
        {
            string typeName = "paidDeveloper";
            Address addr = AddressFactory.GenerateAddressForType(id, typeName);
            PaidDeveloper output = new PaidDeveloper($"{id}", $"{typeName}FirstName{id}", $"{typeName}LastName{id}", addr, Level.Senior,id*1000);
            return output;
        }

        public static PaidManager GenerateNewPaidManager(int id)
        {
            string typeName = "paidManager";

            Address addr = AddressFactory.GenerateAddressForType(id, typeName);
            PaidManager output = new PaidManager($"{id}", $"{typeName}FirstName{id}", $"{typeName}LastName{id}", addr, id*5000);
            return output;
        }

        public static PaidTeamLeader GenerateNewPaidTeamLeader(int id)
        {
            string typeName = "paidTeamLeader";

            Address addr = AddressFactory.GenerateAddressForType(id, typeName);
            PaidTeamLeader output = new PaidTeamLeader($"{id}", $"{typeName}FirstName{id}", $"{typeName}LastName{id}", addr, id*2000);
            return output;
        }

        public static PaidTechnicalTeamLeader GenerateNewPaidTechnicalTeamLeader(int id)
        {
            string typeName = "paidTechnicalTeamLeader";

            Address addr = AddressFactory.GenerateAddressForType(id, typeName);
            PaidTechnicalTeamLeader output = new PaidTechnicalTeamLeader($"{id}", $"{typeName}FirstName{id}", $"{typeName}LastName{id}", addr, Level.Expert, id*3000);
            return output;
        }

        //public static List<PaidDeveloper> GetPaidDevelopersList()
        //{
        //    List<PaidDeveloper> devList = new List<PaidDeveloper>();
        //    devList.Add(GenerateNewPaidDeveloper());
        //    devList.Add(GenerateNewPaidDeveloper2());
        //    return devList;
        //}

        //public static List<string> GetWorkersListId()
        //{
        //    List<string> devList = new List<string>();
        //    devList.Add(GenerateNewPaidDeveloper().ID);
        //    devList.Add(GenerateNewPaidDeveloper2().ID);
        //    return devList;
        //}
    }

}
