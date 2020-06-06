using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DatabaseAccess;
using Microsoft.AspNetCore.Http;

namespace ParkingServisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiParkinge")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetParkinzi()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveParkinge());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
