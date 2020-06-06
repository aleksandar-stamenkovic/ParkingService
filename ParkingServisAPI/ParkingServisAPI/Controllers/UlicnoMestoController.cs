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
    public class UlicnoMestoController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiUlicnaMesta")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUlicnaMesta()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvaUlicnaMesta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajUlicnoMesto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddUlicnoMesto([FromBody] UlicnoMestoView mesto)
        {
            try
            {
                DataProvider.DodajUlicnoMesto(mesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniUlicnoMesto")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeUlicnoMesto([FromBody] UlicnoMestoView mesto)
        {
            try
            {
                DataProvider.AzurirajUlicnoMesto(mesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiulicnoMesto/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteUlicnoMestog(int id)
        {
            try
            {
                DataProvider.ObrisiUlicnoMesto(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
