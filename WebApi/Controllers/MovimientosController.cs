using System;
using AppLogic.CasosDeUso.Pedidos;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.InterfacesCU.Pedidos;
using BusinessLogic.Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientosController : ControllerBase
    {
        private IObtenerMovimientos _obtenerMovimientosCU;
        private IAgregarMovimiento _agregarMovimientoCU;
        private IObtenerAgrupados _obtenerAgrupadosCU;

        public MovimientosController(
            IObtenerMovimientos obtenerMovimientos,
            IAgregarMovimiento agregarMovimiento,
            IObtenerAgrupados obtenerAgrupados
            )
        {
            this._obtenerMovimientosCU = obtenerMovimientos;
            this._agregarMovimientoCU = agregarMovimiento;
            this._obtenerAgrupadosCU = obtenerAgrupados;
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

        [HttpGet(Name = "GetMovimientosAgrupados")]
        public ActionResult<IEnumerable<ResumenMovimientoDTO>> GetMovimientosAgrupados()
        {
            try
            {
                return Ok(this._obtenerAgrupadosCU.GetResumenMovimientos());
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

