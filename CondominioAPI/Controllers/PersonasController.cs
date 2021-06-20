using CondominioAPI.Exceptions;
using CondominioAPI.Models;
using CondominioAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominioAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class PersonasController : Controller
    {
        private IPersonasService _personasService;
        public PersonasController(IPersonasService personasService)
        {
            _personasService = personasService;
        }

        //api/personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaModel>>> GetPersonasAsync()
        {
            try
            {
                var result = await _personasService.GetPersonasAsync();
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
        //api/personas/{personaId}
        [HttpGet("{personaId:long}")]
        public async Task<ActionResult<PersonaModel>> GetPersonaAsync(long personaId)
        {
            try
            {
                var result = await _personasService.GetPersonaAsync(personaId);
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
        //api/personas
        [HttpPost]
        public async Task<ActionResult<PersonaModel>> CreatePersonaAsync([FromBody] PersonaModel newPersona)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _personasService.CreatePersonaAsync(newPersona);
                return Created($"/api/teams/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }        
        //api/personas/{personaId}
        [HttpDelete("{personaId:long}")]
        public async Task<ActionResult<bool>> DeletePersonaAsync(long personaId)
        {
            try
            {
                var result = await _personasService.DeletePersonaAsync(personaId);
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
        //api/personas/{personaId}
        [HttpPut("{personaId:long}")]
        public async Task<ActionResult<PersonaModel>> UpdatePersonaAsync(long personaId, [FromBody] PersonaModel updatedPersona)
        {
            try
            {
                var result = await _personasService.UpdatePersonaAsync(personaId, updatedPersona);
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
