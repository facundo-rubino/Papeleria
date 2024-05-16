using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using AppLogic.DTOs;
using AppLogic.CasosDeUso.Pedidos;
using AppLogic.InterfacesCU.Pedidos;
using BusinessLogic.Excepciones;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AppLogic.InterfacesCU.Articulos;
using Microsoft.CodeAnalysis.Scripting;
using Papeleria.Web.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Elfie.Serialization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    [Logueado]
    public class PedidoController : Controller
    {
        private IRepositorioPedidos _repositorioPedidos;
        private IRepositorioArticulos _repositorioArticulos;
        private IRepositorioClientes _repositorioClientes;
        private static PedidoDTO _pedidoTemporal;
        private IAgregarPedido _agregarPedidoCU;
        private IFindById _articuloPorId;
        private IGetPedidosConCliente _getPedidosConCliente;

        public PedidoController(
            IRepositorioPedidos repositorioPedidos,
            IRepositorioArticulos repositorioArticulos,
            IAgregarPedido agregarPedido,
            IFindById findById,
            IRepositorioClientes repositorioClientes,
            IGetPedidosConCliente getPedidosConCliente

            )
        {
            this._repositorioPedidos = repositorioPedidos;
            this._repositorioArticulos = repositorioArticulos;
            this._agregarPedidoCU = agregarPedido;
            this._articuloPorId = findById;
            this._repositorioClientes = repositorioClientes;
            this._getPedidosConCliente = getPedidosConCliente;
        }
        // GET: PedidoController
        public ActionResult Index(DateTime date)
        {
            IEnumerable<PedidoDTO> aMostrar = new List<PedidoDTO>();

            if (date == DateTime.MinValue )
            {
                aMostrar = this._getPedidosConCliente.GetPedidosConCliente();
            }
            else
            {
                ViewBag.FechaElegida = date.ToShortDateString();
                aMostrar = this._getPedidosConCliente.GetPedidosConCliente(date);
            }

            if(aMostrar.Count() == 0)
            {
                return RedirectToAction("Index", new { error = "No hay pedidos para la fecha elegida"});
            }

            return View(aMostrar);
        }

         

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(this._repositorioPedidos.FindByID(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PedidoController/Create
        public ActionResult Create(string error)
        {
            ViewBag.Articulos = this._repositorioArticulos.FindAll();
            ViewBag.Clientes = this._repositorioClientes.FindAll();
            ViewBag.Error = error;
            if (_pedidoTemporal != null)
            {
                ViewBag.Lineas = _pedidoTemporal.Lineas;
            }
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO pedido, int idCliente, string tipoPedido)
        {
            try
            {
                if (_pedidoTemporal.Lineas.Count <= 0) throw new PedidoNoValidoException("Para realizar un pedido primero debes ingresar líneas");

                if (_pedidoTemporal != null)
                {
                    pedido.Lineas = _pedidoTemporal.Lineas;
                    pedido.ClienteId = idCliente;

                    if (tipoPedido == "comun")
                    {
                        this._agregarPedidoCU.AgregarPedidoComun(pedido);
                    }
                    if (tipoPedido == "express")
                    {
                        pedido.EsPedidoExpress = true;
                        this._agregarPedidoCU.AgregarPedidoExpress(pedido);
                    }
                }
                _pedidoTemporal = null;
                return RedirectToAction(nameof(Index));
            }
            catch (PedidoNoValidoException e)
            {
                ViewBag.error = e.Message;
                return RedirectToAction(nameof(Create), new { error = e.Message });
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return RedirectToAction(nameof(Create), new { error = e.Message });
            }

        }

        [HttpPost]
        public ActionResult FiltroPorFecha(DateTime date)
        {
            try
            {
                return RedirectToAction("Index", new { date = date });
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }   
        }

        public ActionResult Anular(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Anular(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarLinea(int idArticulo, int cantidad)
        {
            try
            {
                Articulo articuloPorId = this._articuloPorId.FindById(idArticulo);
                if (articuloPorId.Stock < 0) throw new PedidoNoValidoException("No tenemos stock de " + articuloPorId.Nombre);

                LineaDTO linea = new LineaDTO { ArticuloId = idArticulo, Cantidad = cantidad, Precio = articuloPorId.PrecioUnitario, Articulo = articuloPorId };
                if (_pedidoTemporal == null)
                {
                    _pedidoTemporal = new PedidoDTO { Lineas = new List<LineaDTO>() };
                }
                _pedidoTemporal.Lineas.Add(linea);
                return RedirectToAction(nameof(Create));
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FiltrarPorFecha(DateTime date)
        {
            try
            {
                return RedirectToAction("Index", date);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }


        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _repositorioPedidos.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

