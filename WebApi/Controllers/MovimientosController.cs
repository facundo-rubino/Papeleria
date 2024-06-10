using System;
using AppLogic.CasosDeUso.Pedidos;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.InterfacesCU.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private IObtenerMovimientos _obtenerMovimientosCU;

        public MovimientosController(
            IObtenerMovimientos obtenerMovimientosCU
            )
        {
            this._obtenerMovimientosCU = obtenerMovimientosCU;
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
    }
}

