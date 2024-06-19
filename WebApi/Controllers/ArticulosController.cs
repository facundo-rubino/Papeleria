using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ArticulosController : ControllerBase
    {
        private IObtenerArticulosAscendente _obtenerArticulosAscendenteCU;
        private IArticulosPorFecha _articulosPorFecha;

        public ArticulosController(
            IObtenerArticulosAscendente obtenerArticulosAscendente,
            IArticulosPorFecha articulosPorFecha
            )
        {
            this._obtenerArticulosAscendenteCU = obtenerArticulosAscendente;
            this._articulosPorFecha = articulosPorFecha;
        }

        /*
       * Obtener todos los articulos ordenados de manera ascendente.
       */
        [HttpGet(Name = "GetArticulosAscendente")]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                return Ok(_obtenerArticulosAscendenteCU.ObtenerArticulosAscendente());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
     * Obtener todos los articulos dado un rango de fechas que hayan tenido movimientos entre dos fechas.
     */
        [HttpGet("GetArticulosPorFechaMovimiento")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetArticulosFechaMovimiento(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                return Ok(_articulosPorFecha.ArticulosPorFecha(fechaIni, fechaFin));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
