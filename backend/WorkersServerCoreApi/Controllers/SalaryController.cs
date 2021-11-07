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
    [Route("api/salary")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        [Route("PaySalary/{workerId}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IActionResult> PaySalary(string workerId) //V
        {
            try
            {
                await SalaryService.Instance().PaySalaryAsync(workerId);
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("ChangeSalary/{workerId}/{newSalary:int}")]
        [AcceptVerbs("POST", "PUT")]
        public async Task<IActionResult> ChangeSalary(string workerId, int newSalary) //V
        {
            try
            {
                await SalaryService.Instance().ChangeSalaryAsync(workerId, newSalary);
                return Ok("");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("GetTotalPaidSalary/{workerId}")]
        [HttpGet]
        public async Task<IActionResult> GetTotalPaidSalary(string workerId) //V
        {
            try
            {
                int totalPaidSalary = await SalaryService.Instance().GetTotalPaidSalaryAsync(workerId);
                return Ok(totalPaidSalary);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

    }
}
