using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BaseLogic.DB;
using BaseLogic.General;
using BaseLogic.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Net;
using System.Web;
using System.Text.Json;


namespace WorkersServerCoreApi.Controllers
{
    [Route("api/hr")]
    [ApiController]
    public class HRController : ControllerBase
    {
        [Route("Hire")]
        [HttpPost]
        [ReadableBodyStream]
        public async Task<IActionResult> Hire()
        {
            try
            {
                HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);

                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    var data = BsonDocument.Parse(body);
                    var workerId = data.GetValue(DBFieldNames.ID).AsString;
                    await HRService.Instance().HireAsync(workerId, data);
                }
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,e);
            }
        }

        [Route("GetBaseWorkersList")]
        [HttpGet]
        public async Task<IActionResult> GetBaseWorkersList() //V
        {
            try
            {
                List<Worker> items = await HRService.Instance().GetBaseWorkersListAsync();
                var result = new List<BsonDocument>(items.Select(obj => obj.ToBsonDocument()));

                return Ok(JsonSerializer.Serialize(result.ToJson()));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("GetEmployeesOfManger/{managerId}")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeesOfManger(string managerId) //V
        {
            try
            {
                List<Worker> items = await HRService.Instance().GetEmployeesOfMangerAsync(managerId);
                var result = new List<BsonDocument>(items.Select(obj => obj.ToBsonDocument()));
                return Ok(JsonSerializer.Serialize(result.ToJson()));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("GetWorkerJsonById/{workerId}")]
        [HttpGet]
        public async Task<IActionResult> GetWorkerJsonById(string workerId) //V
        {
            try
            {
                BsonDocument result = await HRService.Instance().GetWorkerBsonByIdAsync(workerId);
                if (result != null)
                {
                    result.Set("_id", result.GetValue("_id").ToJson());
                    return Ok(JsonSerializer.Serialize(result.ToJson()));
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "not found worker that match that id");
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("AddWorkerToLeader")]
        [AcceptVerbs("POST", "PUT")]
        [ReadableBodyStream]
        public async Task<IActionResult> AddWorkerToLeader() //V
        {
            try
            {
                HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);

                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    var data = BsonDocument.Parse(body);
                    var managerId = data.GetValue("ManagerId").AsString;
                    var workerId = data.GetValue("WorkerId").AsString;
                    await HRService.Instance().AddWorkerToLeaderAsync(managerId, workerId);
                }
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("RemoveWorkerFromLeader")]
        [AcceptVerbs("POST", "PUT")]
        [ReadableBodyStream]
        public async Task<IActionResult> RemoveWorkerFromLeader() //V
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    var data = BsonDocument.Parse(body);
                    var managerId = data.GetValue("ManagerId").AsString;
                    var workerId = data.GetValue("WorkerId").AsString;

                    await HRService.Instance().RemoveWorkerFromLeaderAsync(managerId, workerId);
                }
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("UpdatePersonalAddress/{workerId}")]
        [AcceptVerbs("POST", "PUT")]
        [ReadableBodyStream]
        public async Task<IActionResult> UpdatePersonalAddress(string workerId) //V
        {
            try
            {
                using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
                {
                    string body = await stream.ReadToEndAsync();
                    var data = BsonDocument.Parse(body);
                    var newAddress = BsonSerializer.Deserialize<Address>(data);
                    await HRService.Instance().UpdatePersonalAddressAsync(workerId, newAddress);
                }
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("UpdateProgramingLevel/{workerId}/{newLevel:int}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IActionResult> UpdateProgramingLevel(string workerId, int newLevel) //V
        {
            try
            {
                if (Enum.IsDefined(typeof(DeveloperLevel.Level), newLevel))
                {
                    DeveloperLevel.Level programingLevel = (DeveloperLevel.Level)newLevel;
                    await HRService.Instance().UpdateProgramingLevelAsync(workerId, programingLevel);
                    return Ok("");
                }
                else
                {
                    throw new ArgumentOutOfRangeException(newLevel.ToString(), "The new requested level is not exist");
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("Fire/{workerId}")]
        [AcceptVerbs("POST", "DELETE")]
        public async Task<IActionResult> Fire(string workerId) //V
        {
            try
            {
                await HRService.Instance().FireAsync(workerId);
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
