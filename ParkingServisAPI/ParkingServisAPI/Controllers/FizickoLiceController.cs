using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OracleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizickoLiceController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiFizickaLica")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetFizickaLica()
        {
            try
            {
                return new JsonResult(DataProvider.VratiFizickaLica());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajFizickoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddFizickoLice([FromBody]FizickoLiceView p)
        {
            try
            {
                DataProvider.DodajFizickoLice(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniFizickoLice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeFizickoLice([FromBody]FizickoLiceView p)
        {
            try
            {
                DataProvider.AzurirajFizickoLice(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiFizickoLice/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteFizickoLice(int id)
        {
            try
            {
                DataProvider.obrisiFizickoLice(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
