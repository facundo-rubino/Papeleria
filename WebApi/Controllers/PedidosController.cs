using System;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private IGetPedidosConCliente _getPedidosConClienteCU;

        public PedidosController(
            IGetPedidosConCliente getPedidosConCliente
            )
        {
            this._getPedidosConClienteCU = getPedidosConCliente;
        }

        //[HttpGet(Name = "GetAnuladosDescendente")]
        //public ActionResult<IEnumerable<ArticuloDTO>> Get()
        //{
        //    try
        //    {
        //        return Ok(_getPedidosConClienteCU.GetPedidosAnuladosCliente());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}

