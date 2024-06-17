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

        public ArticulosController(
            IObtenerArticulosAscendente obtenerArticulosAscendente
            )
        {
            this._obtenerArticulosAscendenteCU = obtenerArticulosAscendente;
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
    }
}
