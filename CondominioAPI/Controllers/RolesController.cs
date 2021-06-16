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
    public class RolesController : Controller
    {
        private IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        //api/roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolModel>>> GetRolesAsync()
        {
            try
            {
                var result = await _rolesService.GetRolesAsync();
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
        //api/roles/{rolId}
        [HttpGet("{rolId:long}")]
        public async Task<ActionResult<RolModel>> GetRolAsync(long rolId)
        {
            try
            {
                var result = await _rolesService.GetRolAsync(rolId);
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
        //api/roles
        [HttpPost]
        public async Task<ActionResult<RolModel>> CreateRolAsync([FromBody] RolModel newRol)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _rolesService.CreateRolAsync(newRol);
                return Created($"/api/roles/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/roles/{rolId}
        [HttpDelete("{rolId:long}")]
        public async Task<ActionResult<bool>> DeleteRolAsync(long rolId)
        {
            try
            {
                var result = await _rolesService.DeleteRolAsync(rolId);
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
        //api/roles/{rolId}
        [HttpPut("{rolId:long}")]
        public async Task<ActionResult<RolModel>> UpdateRolAsync(long rolId, [FromBody] RolModel updatedRol)
        {
            try
            {
                var result = await _rolesService.UpdateRolAsync(rolId, updatedRol);
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
