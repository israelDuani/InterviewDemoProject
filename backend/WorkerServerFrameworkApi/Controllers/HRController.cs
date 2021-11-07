using BaseLogic.DB;
using BaseLogic.General;
using BaseLogic.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WorkerServerFrameworkApi.Controllers
{
    public class HRController : ApiController
    {

        [Route("api/hr/GetBaseWorkersList")]
        [HttpGet]
        public async Task<IHttpActionResult> GetBaseWorkersList() //V
        {
            try
            {
                List<Worker> items = await HRService.Instance().GetBaseWorkersListAsync();
                var result = new List<BsonDocument>(items.Select(obj => obj.ToBsonDocument()));

                return Content(HttpStatusCode.OK, result.ToJson());
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/GetEmployeesOfManger/{managerId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetEmployeesOfManger(string managerId) //V
        {
            try
            {
                List<Worker> items = await HRService.Instance().GetEmployeesOfMangerAsync(managerId);
                var result = new List<BsonDocument>(items.Select(obj => obj.ToBsonDocument()));
                return Content(HttpStatusCode.OK, result.ToJson());
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/GetWorkerJsonById/{workerId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetWorkerJsonById(string workerId) //V
        {
            try
            {
                BsonDocument result = await HRService.Instance().GetWorkerBsonByIdAsync(workerId);
                if (result != null)
                {
                    result.Set("_id", result.GetValue("_id").ToJson());
                    return Content(HttpStatusCode.OK, result.ToJson());
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "not found worker that match that id");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/AddWorkerToLeader")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> AddWorkerToLeader() //V
        {
            try
            {
                var request = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                var data = BsonDocument.Parse(request);
                var managerId = data.GetValue("ManagerId").AsString;
                var workerId = data.GetValue("WorkerId").AsString;

                await HRService.Instance().AddWorkerToLeaderAsync(managerId, workerId);
                return Content(HttpStatusCode.OK, "");
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/RemoveWorkerFromLeader")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> RemoveWorkerFromLeader() //V
        {
            try
            {
                var request = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                var data = BsonDocument.Parse(request);
                var managerId = data.GetValue("ManagerId").AsString;
                var workerId = data.GetValue("WorkerId").AsString;

                await HRService.Instance().RemoveWorkerFromLeaderAsync(managerId, workerId);
                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/UpdatePersonalAddress/{workerId}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> UpdatePersonalAddress(string workerId) //V
        {
            try
            {
                var request = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                var data = BsonDocument.Parse(request);
                var newAddress = BsonSerializer.Deserialize<Address>(data);
                await HRService.Instance().UpdatePersonalAddressAsync(workerId,newAddress);
                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/UpdateProgramingLevel/{workerId}/{newLevel:int}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> UpdateProgramingLevel(string workerId, int newLevel) //V
        {
            try
            {
                if (Enum.IsDefined(typeof(DeveloperLevel.Level), newLevel)) 
                {
                    DeveloperLevel.Level programingLevel = (DeveloperLevel.Level)newLevel;
                    await HRService.Instance().UpdateProgramingLevelAsync(workerId, programingLevel);
                    return Content(HttpStatusCode.OK, "");
                }
                else
                {
                    throw new ArgumentOutOfRangeException(newLevel.ToString(), "The new requested level is not exist");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/Fire/{workerId}")]
        [AcceptVerbs("POST", "DELETE")]
        public async Task<IHttpActionResult> Fire(string workerId) //V
        {
            try
            {
                await HRService.Instance().FireAsync(workerId);
                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/hr/Hire")]
        [HttpPost]
        public async Task<IHttpActionResult> Hire() // V
        {
            try
            {
                var request = new StreamReader(HttpContext.Current.Request.InputStream).ReadToEnd();
                var data = BsonDocument.Parse(request);
                var workerId = data.GetValue(DBFieldNames.ID).AsString;
                await HRService.Instance().HireAsync(workerId, data);
                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
