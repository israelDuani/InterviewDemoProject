using BaseLogic.DB;
using BaseLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WorkersServerCoreApi.Controllers
{
    [Route("api/db")]
    [ApiController]
    public class DBController : ControllerBase
    {
        [Route("SwitchDB/{newDBConnectionType:int}")]
        [AcceptVerbs("POST", "PUT")]
        public IActionResult RemoveWorkerFromLeader(int newDBConnectionType) //V
        {
            try
            {
                if (Enum.IsDefined(typeof(DBCommunicatorNames.Kind), newDBConnectionType))
                {
                    DBCommunicatorNames.Kind connectionType = (DBCommunicatorNames.Kind)newDBConnectionType;
                    DBCommunicatorService.SetDBCommunicator(connectionType);
                    return Ok("");
                }
                else
                {
                    throw new ArgumentOutOfRangeException(newDBConnectionType.ToString(), "The requested db comuunicator type is not exist");
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
