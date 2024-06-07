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

        public TiposMovimientoController(IObtenerTipos obtenerTiposMovimientoCU)
        {
            this._obtenerTiposMovimientoCU = obtenerTiposMovimientoCU;
        }

        [HttpGet(Name = "ObtenerTiposMovimiento")]
        public  ActionResult<IEnumerable<TipoMovimientoDTO>> Get()
        {
            return  Ok(this._obtenerTiposMovimientoCU.ObtenerTiposMovimiento());
        }


        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipoMovimientoDTO> Create([FromBody] TipoMovimientoDTO tipoMovimientoDTO)
        {
            try
            {
                this._addTeam.AddTeam(tipoMovimientoDTO);
                return Created("api/Teams", tipoMovimientoDTO);
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


        // GET api/<TiposMovimientoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TiposMovimientoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TiposMovimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TiposMovimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
