using System.Collections.Generic;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.InterfacesCU.Movimientos;
using BussinessLogic.Entidades;
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
        private IFindAllArticulosPaginado _findAllPaginado;

        public ArticulosController(
            IObtenerArticulosAscendente obtenerArticulosAscendente,
            IArticulosPorFecha articulosPorFecha,
            IFindAllArticulosPaginado findAllPaginado
            )
        {
            this._obtenerArticulosAscendenteCU = obtenerArticulosAscendente;
            this._articulosPorFecha = articulosPorFecha;
            this._findAllPaginado = findAllPaginado;
        }

        /// <summary>
        /// Metodo que trae todos los articulos de manera ascendente
        /// </summary>
        /// <returns>Devuelve una lista con los movimientos en la base de datos</returns>
        /// <response code="200">Retorna los artículos</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Name = "GetArticulosAscendente")]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            try
            {
                IEnumerable<ArticuloDTO> articulosList = _obtenerArticulosAscendenteCU.ObtenerArticulosAscendente();
                if (articulosList.Count() == 0)
                    return NoContent();
                return Ok(articulosList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtener los articulos paginados
        /// </summary>
        /// <param name="pageNumber">Página actual</param>
        /// <returns>Articulos paginados</returns>
        /// <response code="200">Retorna los articulos por la página</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("Page/{pageNumber}")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetArticulosPaginados(int pageNumber)
        {
            if (pageNumber < 1) { return BadRequest("La pag debe ser 0 o más"); }
            IEnumerable<ArticuloDTO> articulosList = this._findAllPaginado.FindAllPaginado(pageNumber);
            if (articulosList.Count() == 0) { return NoContent(); }
            return Ok(articulosList);
        }

        /// <summary>
        ///  Articulos movidos dado un rango de fechas 
        /// </summary>
        /// <param name="fechaIni">Fecha desde</param>
        /// <param name="fechaFin">Fecha hasta</param>
        /// <returns>Articulos dado un rango de fechas que hayan tenido movimientos entre dos fechas</returns>
        /// <response code="200">Retorna los articulos filtrados por fecha</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="400">Parametros no válidos</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetArticulosPorFechaMovimiento")]
        public ActionResult<IEnumerable<ArticuloDTO>> GetArticulosFechaMovimiento(DateTime fechaIni, DateTime fechaFin)
        {
            try
            {

                if (fechaIni == DateTime.MinValue && fechaFin == DateTime.MinValue) { return BadRequest("Verifique fechas"); }
                IEnumerable<ArticuloDTO> articulosList = _articulosPorFecha.ArticulosPorFecha(fechaIni, fechaFin);
                if (articulosList.Count() == 0) { return NoContent(); }
                return Ok(articulosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
