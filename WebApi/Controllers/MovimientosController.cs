using System;
using AppLogic.CasosDeUso.Pedidos;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.InterfacesCU.Pedidos;
using BusinessLogic.Excepciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private IObtenerMovimientos _obtenerMovimientosCU;
        private IAgregarMovimiento _agregarMovimientoCU;

        public MovimientosController(
            IObtenerMovimientos obtenerMovimientos,
            IAgregarMovimiento agregarMovimiento
            )
        {
            this._obtenerMovimientosCU = obtenerMovimientos;
            this._agregarMovimientoCU = agregarMovimiento;
        }

        [HttpGet(Name = "GetMovimientos")]
        public ActionResult<IEnumerable<MovimientoDTO>> Get()
        {
            try
            {
                return Ok(_obtenerMovimientosCU.ObtenerMovimientos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MovimientoDTO> Create([FromBody] MovimientoDTO movimientoDTO)
        {
            try
            {
                this._agregarMovimientoCU.AgregarMovimiento(movimientoDTO);
                return Created("Movimiento", movimientoDTO);
            }
            catch (MovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Error inesperado con la base de datos");
            }

        }
    }
}

