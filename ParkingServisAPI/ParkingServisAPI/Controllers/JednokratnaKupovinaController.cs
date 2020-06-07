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
    public class JednokratnaKupovinaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiJednokratneKupovine")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetJednokratneKupovine()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveJednokratneKupovine());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajJednokratnuKupovinu/{voziloID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddJednokratnaKupovina([FromBody] JednokratnaKupovinaView jednokratna, int voziloID)
        {
            try
            {
                DataProvider.DodajJednokratnuKupovinu(jednokratna, voziloID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniJednokratnuKupovinu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeParking([FromBody] JednokratnaKupovinaView jednokratna)
        {
            try
            {
                DataProvider.AzurirajJednokratnuKupovinu(jednokratna);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiJednokratnuKupovinu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteJednokratnaKupovina(int id)
        {
            try
            {
                DataProvider.ObrisiJednokratnuKupovinu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
