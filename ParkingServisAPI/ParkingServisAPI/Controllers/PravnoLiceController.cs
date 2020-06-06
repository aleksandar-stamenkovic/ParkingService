using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OracleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PravnoLiceController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiPravnaLica")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPravnaLica()
        {
            try
            {
                return new JsonResult(DataProvider.VratiPravnaLica());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPravnoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPravnoLice([FromBody]PravnoLiceView p)
        {
            try
            {
                DataProvider.DodajPravnoLice(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPravnoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePravnoLice([FromBody]PravnoLiceView p)
        {
            try
            {
                DataProvider.AzurirajPravnoLice(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPravnoLice/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePravnoLice(int id)
        {
            try
            {
                DataProvider.obrisiPravnoLice(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
