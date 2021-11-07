using BaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WorkerServerFrameworkApi.Controllers
{

    public class SalaryController : ApiController
    {

        [Route("api/Salary/PaySalary/{workerId}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> PaySalary(string workerId) //V
        {
            try
            {
                await SalaryService.Instance().PaySalaryAsync(workerId);
                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        [Route("api/Salary/ChangeSalary/{workerId}/{newSalary:int}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> ChangeSalary(string workerId, int newSalary) //V
        {
            try
            {
                await SalaryService.Instance().ChangeSalaryAsync(workerId, newSalary);
                return Content(HttpStatusCode.OK, "");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        [Route("api/Salary/GetTotalPaidSalary/{workerId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTotalPaidSalary(string workerId) //V
        {
            try
            {
                int totalPaidSalary = await SalaryService.Instance().GetTotalPaidSalaryAsync(workerId);
                return Content(HttpStatusCode.OK, totalPaidSalary);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
