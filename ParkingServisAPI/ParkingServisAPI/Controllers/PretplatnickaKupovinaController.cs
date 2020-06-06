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
    public class PretplatnickaKupovinaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiPretplatnickeKupovine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPretplatnickeKupovine()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvePretplatnickeKupovine());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPretplatnickuKupovinu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddPretplatnickaKupovina([FromBody] PretplatnickaKupovinaView pretplatnicka)
        {
            try
            {
                DataProvider.DodajPretplatnickuKupovinu(pretplatnicka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniPretplatnickuKupovinu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangePretplatnickaKupovina([FromBody] PretplatnickaKupovinaView pretplatnicka)
        {
            try
            {
                DataProvider.AzurirajPretplatnickuKupovinu(pretplatnicka);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPretplatnickuKupovinu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeletePretplatnickaKupovina(int id)
        {
            try
            {
                DataProvider.ObrisiPretplatnickuKupovinu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
