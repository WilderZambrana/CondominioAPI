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
    public class LoginsController : Controller
    {
        private ILoginsService _loginsService;
        public LoginsController(ILoginsService loginsService)
        {
            _loginsService = loginsService;
        }

        //api/logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginModel>>> GetLoginsAsync()
        {
            try
            {
                var result = await _loginsService.GetLoginsAsync();
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
        //api/logins/{loginId}
        [HttpGet("{loginId:long}")]
        public async Task<ActionResult<LoginModel>> GetLoginAsync(long loginId)
        {
            try
            {
                var result = await _loginsService.GetLoginAsync(loginId);
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
        //api/logins
        [HttpPost]
        public async Task<ActionResult<LoginModel>> CreateLoginAsync([FromBody] LoginModel newLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _loginsService.CreateLoginAsync(newLogin);
                return Created($"/api/logins/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
        //api/logins/{loginId}
        [HttpDelete("{loginId:long}")]
        public async Task<ActionResult<bool>> DeleteLoginAsync(long loginId)
        {
            try
            {
                var result = await _loginsService.DeleteLoginAsync(loginId);
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
        //api/logins/{loginId}
        [HttpPut("{loginId:long}")]
        public async Task<ActionResult<LoginModel>> UpdateLoginAsync(long loginId, [FromBody] LoginModel updatedLogin)
        {
            try
            {
                var result = await _loginsService.UpdateLoginAsync(loginId, updatedLogin);
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
