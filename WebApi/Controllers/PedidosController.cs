using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;
using AppLogic.InterfacesCU.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private IObtenerAnuladosDescendente _obtenerAnuladosDescendenteCU;

        public PedidosController(
            IObtenerAnuladosDescendente obtenerAnuladosDescendente
            )
        {
            this._obtenerAnuladosDescendenteCU = obtenerAnuladosDescendente;
        }

        [HttpGet(Name = "GetAnuladosDescendente")]
        public ActionResult<IEnumerable<ArticuloDTO>> Get()
        {
            return Ok(_obtenerAnuladosDescendenteCU.ObtenerAnuladosDescendente());
        }
    }
}

