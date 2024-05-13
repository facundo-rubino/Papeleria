using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticulosController : ControllerBase
    {
        private IObtenerArticulosAscendente _obtenerArticulosAscendenteCU;

        public ArticulosController(
            IObtenerArticulosAscendente obtenerArticulosAscendente
            )
        {
            this._obtenerArticulosAscendenteCU = obtenerArticulosAscendente;
        }

        [HttpGet(Name = "GetArticulosAscendente")]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            return Ok(_obtenerArticulosAscendenteCU.ObtenerArticulosAscendente());
        }
    }
}
