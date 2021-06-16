using CondominioAPI.Exceptions;
using CondominioAPI.Models;
using CondominioAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Controllers
{
    [Route("api/[controller]")]
    public class CobrosController : Controller
    {
        private ICobrosService _cobrosService;
        public CobrosController(ICobrosService cobrosService)
        {
            _cobrosService = cobrosService;
        }

        //api/cobros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CobroModel>>> GetCobrosAsync()
        {
            try
            {
                var result = await _cobrosService.GetCobrosAsync();
                return Ok(result);
            }
            catch (InvalidOperationItemException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/cobros/{alquilerId}
        [HttpGet("{cobroId:long}")]
        public async Task<ActionResult<CobroModel>> GetCobroAsync(long cobroId)
        {
            try
            {
                var result = await _cobrosService.GetCobroAsync(cobroId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/cobros
        [HttpPost]
        public async Task<ActionResult<CobroModel>> CreateCobroAsync([FromBody] CobroModel newCobro)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _cobrosService.CreateCobroAsync(newCobro);
                return Created($"/api/cobros/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/cobros/{cobroId}
        [HttpDelete("{cobroId:long}")]
        public async Task<ActionResult<bool>> DeleteCobroAsync(long cobroId)
        {
            try
            {
                var result = await _cobrosService.DeleteCobroAsync(cobroId);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/cobros/{cobroId}
        [HttpPut("{cobroId:long}")]
        public async Task<ActionResult<CobroModel>> UpdateCobroAsync(long cobroId, [FromBody] CobroModel updatedCobro)
        {
            try
            {
                var result = await _cobrosService.UpdateCobroAsync(cobroId, updatedCobro);
                return Ok(result);
            }
            catch (NotFoundItemException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}
