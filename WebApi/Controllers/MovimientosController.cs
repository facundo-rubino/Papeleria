using System;
using AppLogic.CasosDeUso.Articulos;
using AppLogic.CasosDeUso.Movimientos;
using AppLogic.CasosDeUso.Pedidos;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Movimientos;
using AppLogic.InterfacesCU.Pedidos;
using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using BussinessLogic.Entidades;
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
        private IMovimientoPorArticuloTipo _movimientoPorArticuloTipoCU;
        private IFindAllMovimientosPaginado _findAllMovimientosPaginadoCU;

        public MovimientosController(
            IObtenerMovimientos obtenerMovimientos,
            IAgregarMovimiento agregarMovimiento,
            IObtenerAgrupados obtenerAgrupados,
            IMovimientoPorArticuloTipo movimientoPorArticuloTipo,
            IFindAllMovimientosPaginado findAllMovimientosPaginadoCU
            )
        {
            this._obtenerMovimientosCU = obtenerMovimientos;
            this._agregarMovimientoCU = agregarMovimiento;
            this._obtenerAgrupadosCU = obtenerAgrupados;
            this._movimientoPorArticuloTipoCU = movimientoPorArticuloTipo;
            this._findAllMovimientosPaginadoCU = findAllMovimientosPaginadoCU;
        }

        /// <summary>
        /// Metodo que trae todos los movimientos
        /// </summary>
        /// <returns>Devuelve una lista con los movimientos en la base de datos</returns>
        /// <response code="200">Retorna los movimientos</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Name = "GetMovimientos")]
        public ActionResult<IEnumerable<MovimientoDTO>> Get()
        {
            try
            {
                IEnumerable<MovimientoDTO> movimientosList = _obtenerMovimientosCU.ObtenerMovimientos();
                if (movimientosList.Count() == 0)
                    return NoContent();
                return Ok(movimientosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener los movimientos paginados
        /// </summary>
        /// <param name="pageNumber">Página actual</param>
        /// <returns>Movimientos paginados</returns>
        /// <response code="200">Retorna los movimientos por la página</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("Page/{pageNumber}")]
        public ActionResult<IEnumerable<MovimientoDTO>> GetMovimientosPaginados(int pageNumber)
        {
            if (pageNumber < 1) { return BadRequest("La pag debe ser 0 o más"); }
            IEnumerable<MovimientoDTO> movimientos = this._findAllMovimientosPaginadoCU.FindAllPaginado(pageNumber);
            if (movimientos.Count() == 0)
                return NoContent();
            return Ok(movimientos);
        }


        /// <summary>
        /// Obtener información de resumen de las cantidades movidas
        /// </summary>
        /// <returns>Movimientos agrupados por año y status 200, o status correspondiente al error</returns>
        /// <response code="200">Retorna los movimientos agrupados</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("MovimientosAgrupados")]
        public ActionResult<IEnumerable<ResumenMovimientoDTO>> GetMovimientosAgrupados()
        {
            try
            {
                IEnumerable<ResumenMovimientoDTO> movimientosList = this._obtenerAgrupadosCU.GetResumenMovimientos();
                if (movimientosList.Count() == 0)
                    return NoContent();
                return Ok(movimientosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Obtener los movimientos por un articulo y un tipo de movimiento
        /// </summary>
        /// <returns> Devuelve todos los datos del movimiento de stock y del tipo de movimento tomando en cuenta el artículo recibido</returns>
        /// <param name="articuloId">Id del artículo a buscar</param>
        /// <param name="tipoId">Id del tipo a buscar</param>
        /// <response code="200">Retorna los movimientos filtrados</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="401">Error de autorización</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("MovimientosPorArticuloTipo")]
        public ActionResult<IEnumerable<MovimientoDTO>> GetMovimientosPorArticuloTipo(int articuloId, int tipoId)
        {
            try
            {
                IEnumerable<MovimientoDTO> movimientosList = this._movimientoPorArticuloTipoCU.GetMovimientosPorArticuloTipo(articuloId, tipoId);
                if (movimientosList.Count() == 0)
                    return NoContent();
                return Ok(movimientosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Metodo para crear un movimiento
        /// </summary>
        /// <param name="movimientoDTO">Movimiento a crear</param>
        /// <returns>Tipo de movimiento</returns>
        /// <response code="201">Objeto creado correctamente</response>
        /// <response code="400">El objeto enviado no es válido</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("")]
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

