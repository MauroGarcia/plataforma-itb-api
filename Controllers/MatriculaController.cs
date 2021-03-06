﻿using Microsoft.AspNetCore.Mvc;
using PlataformaITB.API.Infrastructure;
using PlataformaITB.API.Models;
using PlataformaITB.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlataformaITB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [BasicAuth]
    public class MatriculaController : ControllerBase
    {
        private readonly IPedaMatriculasService _matriculaService;
        private readonly ItbDadosContext _itbDadosContext;

        public MatriculaController(IPedaMatriculasService categoryService, ItbDadosContext itbDadosContext)
        {
            _matriculaService = categoryService;
            _itbDadosContext = itbDadosContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PedaMatriculas>> Get()
        {
            return Ok(_itbDadosContext.PedaMatriculas.Where(c => c.IdFrqa.Equals(94)).Take(50));
        }

        [HttpGet("{id}")]
        public ActionResult<PedaMatriculas> GetMatriculaById(int id)
        {
            return Ok(_matriculaService.ObterMatriculaDynamic(id));
        }
        
        [HttpDelete("codigo-matricula/{codigoMatricula}")]
        public IActionResult DeleteByCodigoMatricula(string codigoMatricula)
        {
            try
            {
                _matriculaService.ExcluirMatriculaPorCodigo(codigoMatricula, "api.plataformaitb.com.br");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { success = false, message = e.Message });
                //return BadRequest(e.Message);
            }

            return new OkObjectResult(new { success = true, message = string.Empty });

            //return NoContent();
        }

        [HttpGet("codigo-matricula/{codigoMatricula}")]
        public IActionResult GetByCodigoMatricula(string codigoMatricula)
        {
            try
            {
                return Ok(_matriculaService.ObterMatriculaPorCodigoMatricula(codigoMatricula));
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { success = false, message = e.Message });
            }
        }

        [HttpPost("codigo-matricula/{codigoMatricula}/cancelar")]
        public IActionResult CancelarMatriculaPorCodigoMatricula(string codigoMatricula, [FromBody] CancelarMatriculaModel cancelarMatriculaModel)
        {
            try
            {
                _matriculaService.CancelarMatricula(codigoMatricula, $"api.plataformaitb ({cancelarMatriculaModel.SistemaOrigem}) - Matrícula cancelada", "api.plataformaitb.com.br");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { success = false, message = e.Message });
            }

            return new OkObjectResult(new { success = true, message = string.Empty });
        }

        [HttpPost("{id}/cancelar")]
        public IActionResult CancelarMatriculaPorId(int id)
        {
            return Ok();
        }

        [HttpPost("atualizar-codigo-externo")]
        public IActionResult AtualizarCodigoExterno([FromBody] AtualizarCodigoExternoModel atualizarCodigoExternoModel)
        {
            try
            {
                _matriculaService.AtualizarCodigoExternoMatriculas(atualizarCodigoExternoModel.CodigoPolo, atualizarCodigoExternoModel.CodigoCorp, atualizarCodigoExternoModel.CodigoHub);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { success = false, message = e.Message });
            }

            return new OkObjectResult(new { success = true, message = "Matriculas atualizadas." });
        }

        [HttpPost("codigo-matricula/{codigoMatricula}/ajusteProficiencia")]
        public IActionResult CorrigeProficienciaMatricula(string codigoMatricula)
        {
            try
            {
                _matriculaService.CorrigeProficienciaMatricula(codigoMatricula);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new { success = false, message = e.Message });
            }

            return new OkObjectResult(new { success = true, message = string.Empty });
        }
    }

    public class AtualizarCodigoExternoModel
    {
        public int CodigoPolo { get; set; }
        public int CodigoCorp { get; set; }
        public int CodigoHub { get; set; }
    }

    public class CancelarMatriculaModel
    {
        public string SistemaOrigem { get; set; }
    }
}
