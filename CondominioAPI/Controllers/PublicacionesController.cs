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
    //[Route("api/personas/{personaId:long}/[controller]")]
    public class PublicacionesController : Controller
    {
        private IPublicacionesService _publicacionesService;
        public PublicacionesController(IPublicacionesService publicacionesService)
        {
            _publicacionesService = publicacionesService;
        }

        //api/publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicacionModel>>> GetPublicacionesAsync()
        {
            try
            {
                var result = await _publicacionesService.GetPublicacionesAsync();
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
        //api/publicaciones/{publicacionId}
        [HttpGet("{publicacionId:long}")]
        public async Task<ActionResult<PublicacionModel>> GetPublicacionAsync(long publicacionId)
        {
            try
            {
                var result = await _publicacionesService.GetPublicacionAsync(publicacionId);
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
        //api/publicaciones
        [HttpPost]
        public async Task<ActionResult<PublicacionModel>> CreatePublicacionAsync([FromBody] PublicacionModel newPublicacion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _publicacionesService.CreatePublicacionAsync(newPublicacion);
                //return Created($"/api/publicaciones/{result.Id}", result);
                return Created($"/api/publicaciones/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/publicaciones/{publicacionId}
        [HttpDelete("{publicacionId:long}")]
        public async Task<ActionResult<bool>> DeletePublicacionAsync(long publicacionId)
        {
            try
            {
                var result = await _publicacionesService.DeletePublicacionAsync(publicacionId);
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
        //api/publicaciones/{publicacionId}
        [HttpPut("{publicacionId:long}")]
        public async Task<ActionResult<PublicacionModel>> UpdatePublicacionAsync(long publicacionId, [FromBody] PublicacionModel updatedPublicacion)
        {
            try
            {
                var result = await _publicacionesService.UpdatePublicacionAsync(publicacionId, updatedPublicacion);
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
