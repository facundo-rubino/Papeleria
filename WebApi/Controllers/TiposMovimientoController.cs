using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using BusinessLogic.Entidades;
using BusinessLogic.Excepciones;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/TiposMovimiento")]
    [ApiController]
    public class TiposMovimientoController : ControllerBase
    {
        private IObtenerTipos _obtenerTiposMovimientoCU;
        private IAgregarTipo _agregarTipoMovimientoCU;
        private IObtenerTipoPorId _obtenerTipoPorIdCU;
        private IEliminarTipo _eliminarTipoCU;
        private IActualizarTipo _actualizarTipoCU;

        public TiposMovimientoController(
            IObtenerTipos obtenerTiposMovimientoCU,
            IAgregarTipo agregarTipoMovimientoCU,
            IObtenerTipoPorId obtenerTipoPorId,
            IActualizarTipo actualizarTipo,
            IEliminarTipo eliminarTipo
            )
        {
            this._obtenerTiposMovimientoCU = obtenerTiposMovimientoCU;
            this._agregarTipoMovimientoCU = agregarTipoMovimientoCU;
            this._obtenerTipoPorIdCU = obtenerTipoPorId;
            this._actualizarTipoCU = actualizarTipo;
            this._eliminarTipoCU = eliminarTipo;
        }
        /// <summary>
        /// Metodo que trae todos tipos de movimiento
        /// </summary>
        /// <returns>Devuelve una lista con los tipos de movimiento en la base de datos</returns>
        /// <response code="200">Retorna los tipos de movimiento</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Name = "ObtenerTiposMovimiento")]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return Ok(this._obtenerTiposMovimientoCU.ObtenerTiposMovimiento());
        }

        /// <summary>
        /// Metodo que trae el tipo de movimiento por un Id
        /// </summary>
        /// <param name="tipoId">Id del tipo a buscar</param>
        /// <returns>Tipo de movimiento</returns>
        /// <response code="200">Retorna el tipo de movimiento correspondiente al id dado</response>
        /// <response code="204">No hay contenido para mostrar</response>
        /// <response code="400">El id no es válido</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{tipoId}")]
        public ActionResult<TipoMovimientoDTO> GetTipoPorId(int tipoId)
        {
            if (tipoId <= 0)
                return BadRequest("El id debe ser positivo");

            TipoMovimientoDTO toReturn = this._obtenerTipoPorIdCU.GetTipoPorId(tipoId);

            if (toReturn != null) return Ok(toReturn);
            return NoContent();
        }



        /// <summary>
        /// Metodo para crear un tipo de movimiento
        /// </summary>
        /// <param name="tipoMovimientoDTO">Tipo de movimiento a crear</param>
        /// <returns>Tipo de movimiento</returns>
        /// <response code="201">Se crea el tipo correctamente</response>
        /// <response code="400">El objeto enviado no es válido</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("")]
        public ActionResult<TipoMovimientoDTO> Create([FromBody] TipoMovimientoDTO tipoMovimientoDTO)
        {
            try
            {
                this._agregarTipoMovimientoCU.AgregarTipo(tipoMovimientoDTO);
                return Created("TiposMovimiento", tipoMovimientoDTO);
            }
            catch (TipoMovimientoNoValidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Error inesperado con la base de datos");
            }

        }
        /// <summary>
        /// Metodo para borrar tipo de movimiento por un Id
        /// </summary>
        /// <param name="tipoMovimientoId">Id del tipo a borrar</param>
        /// <response code="200">Tipo de movimiento eliminado correctamente</response>
        /// <response code="400">El id no es válido</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{tipoMovimientoId}")]
        public ActionResult<TipoMovimientoDTO> DeleteTipo(int tipoMovimientoId)
        {
            try
            {
                this._eliminarTipoCU.DeleteTipo(tipoMovimientoId);
                return Ok("El tipo de movimiento con id " + tipoMovimientoId + " fue borrado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para actualizar tipo de movimiento 
        /// </summary>
        /// <param name="tipoMovimientoDTO">Tipo de movimiento a borrar</param>
        /// <response code="200">Tipo de movimiento actualizado correctamente</response>
        /// <response code="400">El objeto enviado no es válido</response>
        /// <response code="500">Error inesperado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{tipoId}")]
        public ActionResult<TipoMovimientoDTO> UpdateTipo([FromBody] TipoMovimientoDTO tipoMovimientoDTO)
        {
            try
            {
                this._actualizarTipoCU.ActualizarTipo(tipoMovimientoDTO);
                return Ok("El tipo de movimiento " + tipoMovimientoDTO.Nombre + " fue actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
