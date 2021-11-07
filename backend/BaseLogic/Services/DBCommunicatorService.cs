using BaseLogic.DB;
using System;

namespace BaseLogic.Services
{
    public static class DBCommunicatorService
    {
        private static IDBCommunicator SelectedCommunicator = null;

        public static IDBCommunicator GetCommunicator()
        {
            if(SelectedCommunicator == null)
            {
                // return the default communicator
                SelectedCommunicator = MongoCommunicator.Instance();
            }
            return SelectedCommunicator;
        }

        public static void SetDBCommunicator(DBCommunicatorNames.Kind db)
        {
            // set new communicator
            switch (db)
            {
                case DBCommunicatorNames.Kind.Mongo:
                    SelectedCommunicator = MongoCommunicator.Instance();
                    break;
                case DBCommunicatorNames.Kind.MySql:
                    SelectedCommunicator = MySqlCommunicator.Instance();
                    break;
                default:
                    throw new Exception($"not found matching db communicator to {Enum.GetName(typeof(DBCommunicatorNames.Kind), db)}");
            }
        }
    }
}
