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
    }
}
