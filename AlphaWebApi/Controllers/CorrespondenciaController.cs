using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Alpha.BussinesLayer.Dto;
using Alpha.BussinesLayer.Contracts;

namespace Alpha.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CorrespondenciaController : ControllerBase
    {
        private readonly ICorrespondenciaBL _correspondenciaBL;
        public CorrespondenciaController(ICorrespondenciaBL correspondenciaBL) 
        {
            _correspondenciaBL = correspondenciaBL;
        }

        /// <summary>
        /// Retorna todas las comunicaciones radicadas en el sistema implementando paginación
        /// </summary>
        /// <returns>Listado de comunicaciones radicadas</returns>
        [HttpGet]
        public IActionResult Get(int take, int skip) 
        {
            if(take < 1 || skip < 0) 
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                var result = _correspondenciaBL.Get(take, skip);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una comunicación mediante el número de radicado
        /// </summary>
        /// <param name="numeroRadicado">número de radicado de la comunicación a obtener</param>
        /// <returns>Comunicación registrada en el sistema</returns>
        [HttpGet]
        [Route("GetByRadicado")]
        public IActionResult GetByRadicado(string numeroRadicado)
        {
            if (string.IsNullOrEmpty(numeroRadicado))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                var result = _correspondenciaBL.Get(numeroRadicado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Radica una nueva comunicación en el sistema
        /// </summary>
        /// <param name="correspondencia">Dto con la información a registrar de la comunicación</param>
        /// <returns>número de radicado de la comunicación</returns>
        [HttpPost]
        public IActionResult Post(CorrespondenciaRequestDto correspondencia)
        {
            try
            {
                var result = _correspondenciaBL.Create(correspondencia);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
