using Microsoft.AspNetCore.Mvc;
using PlataformaITB.API.Infrastructure;
using PlataformaITB.API.Models;
using PlataformaITB.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
