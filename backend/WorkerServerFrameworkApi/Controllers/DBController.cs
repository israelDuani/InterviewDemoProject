using BaseLogic.DB;
using BaseLogic.Services;
using System;
using System.Net;
using System.Web.Http;

namespace WorkerServerFrameworkApi.Controllers
{
    public class DBController : ApiController
    {
        [Route("api/DB/SwitchDB/{newDBConnectionType:int}")]
        [HttpPut]
        public IHttpActionResult RemoveWorkerFromLeader(int newDBConnectionType) //V
        {
            try
            {
                if (Enum.IsDefined(typeof(DBCommunicatorNames.Kind), newDBConnectionType))
                {
                    DBCommunicatorNames.Kind connectionType = (DBCommunicatorNames.Kind)newDBConnectionType;
                    DBCommunicatorService.SetDBCommunicator(connectionType);
                    return Content(HttpStatusCode.OK, "");
                }
                else
                {
                    throw new ArgumentOutOfRangeException(newDBConnectionType.ToString(), "The requested db comuunicator type is not exist");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
