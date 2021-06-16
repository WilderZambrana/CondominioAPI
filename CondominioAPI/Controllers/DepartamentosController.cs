﻿using CondominioAPI.Exceptions;
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
    public class DepartamentosController : Controller
    {
        private IDepartamentosService _departamentosService;
        public DepartamentosController(IDepartamentosService departamentosService)
        {
            _departamentosService = departamentosService;
        }

        //api/departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoModel>>> GetDepartamentosAsync()
        {
            try
            {
                var result = await _departamentosService.GetDepartamentosAsync();
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
        public async Task<ActionResult<DepartamentoModel>> CreateDepartamentoAsync([FromBody] DepartamentoModel newDepartamento)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _departamentosService.CreateDepartamentoAsync(newDepartamento);
                return Created($"/api/departamentos/{result.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something unexpected happened.");
            }
        }
    }
}