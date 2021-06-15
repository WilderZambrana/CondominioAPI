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
    public class AlquileresController : Controller
    {
        private IAlquileresService _alquileresService;
        public AlquileresController(IAlquileresService alquileresService)
        {
            _alquileresService = alquileresService;
        }

        //api/alquileres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlquilerModel>>> GetAlquileresAsync()
        {
            try
            {
                var result = await _alquileresService.GetAlquileresAsync();
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
        public async Task<ActionResult<AlquilerModel>> CreateAlquilerAsync([FromBody] AlquilerModel newAlquiler)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _alquileresService.CreateAlquilerAsync(newAlquiler);
                return Created($"/api/alquileres/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}
