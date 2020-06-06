using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingServisAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JavnoMestoController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiJavnaMesta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetJavnaMesta()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvaJavnaMesta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajJavnoMesto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddJavnoMesto([FromBody] JavnoMestoView javnoMesto)
        {
            try
            {
                DataProvider.DodajJavnoMesto(javnoMesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniJavnoMesto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeJavnoMesto([FromBody] JavnoMestoView javnoMesto)
        {
            try
            {
                DataProvider.AzurirajJavnoMesto(javnoMesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiJavnoMesto/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteJavnoMestog(int id)
        {
            try
            {
                DataProvider.ObrisiJavnoMesto(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
