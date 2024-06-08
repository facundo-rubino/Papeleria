using AppLogic.DTOs;
using AppLogic.InterfacesCU.TiposMovimiento;
using BusinessLogic.Excepciones;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TiposMovimientoController : ControllerBase
    {
        private IObtenerTipos _obtenerTiposMovimientoCU;
        private IAgregarTipo _agregarTipoMovimientoCU;
        private IObtenerTipoPorId _obtenerTipoPorId;

        public TiposMovimientoController(
            IObtenerTipos obtenerTiposMovimientoCU,
            IAgregarTipo agregarTipoMovimientoCU,
            IObtenerTipoPorId obtenerTipoPorId
            )
        {
            this._obtenerTiposMovimientoCU = obtenerTiposMovimientoCU;
            this._agregarTipoMovimientoCU = agregarTipoMovimientoCU;
            this._obtenerTipoPorId = obtenerTipoPorId;
        }

        [HttpGet(Name = "ObtenerTiposMovimiento")]
        public ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return Ok(this._obtenerTiposMovimientoCU.ObtenerTiposMovimiento());
        }

        [HttpGet("{tipoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> GetTipoPorId(int tipoId)
        {
            if (tipoId <= 0)
            {
                return BadRequest("El id no debe ser positivo");
            }
            TipoMovimientoDTO toReturn = this._obtenerTipoPorId.GetTipoPorId(tipoId);
            if (toReturn != null)
            {
                return Ok(toReturn);
            }
            return NoContent();
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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



    }
}
