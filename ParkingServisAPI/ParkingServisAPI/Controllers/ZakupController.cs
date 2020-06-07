using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OracleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZakupController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiZakupe")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetZakup()
        {
            try
            {
                return new JsonResult(DataProvider.VratiZakup());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZakup/{mestoID}/{voziloID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddZakup([FromBody]ZakupView p, int mestoID, int voziloID)
        {
            try
            {
                DataProvider.DodajZakup(p, mestoID, voziloID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniZakup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeZakup([FromBody]ZakupView p)
        {
            try
            {
                DataProvider.AzurirajZakup(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiZakup/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteZakup(int id)
        {
            try
            {
                DataProvider.obrisiZakup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
