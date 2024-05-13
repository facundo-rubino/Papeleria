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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    public class PedidoController : Controller
    {
        private IRepositorioPedidos _repositorioPedidos;
        private IRepositorioArticulos _repositorioArticulos;
        private static PedidoDTO _pedidoTemporal;
        private IAgregarPedido _agregarPedidoCU;
        private IFindById _articuloPorId;

        public PedidoController(IRepositorioPedidos repositorioPedidos, IRepositorioArticulos repositorioArticulos, IAgregarPedido agregarPedido, IFindById findById)
        {
            this._repositorioPedidos = repositorioPedidos;
            this._repositorioArticulos = repositorioArticulos;
            this._agregarPedidoCU = agregarPedido;
            this._articuloPorId = findById;
        }
        // GET: PedidoController
        public ActionResult Index()
        {
            return View(this._repositorioPedidos.FindAll());
            //return View();
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
        public ActionResult Create(PedidoDTO pedido)
        {

            try
            {
                if (_pedidoTemporal != null && _pedidoTemporal.Lineas.Count > 0)
                {
                    pedido.Lineas = _pedidoTemporal.Lineas;
                }

                this._agregarPedidoCU.AgregarPedido(pedido);
                _pedidoTemporal = null;
                return RedirectToAction(nameof(Index));
            }
            catch (PedidoNoValidoException e)
            {
                return RedirectToAction(nameof(Create), new { error = e.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Create), new { error = e.Message });
            }

        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarLinea(int id, int cantidad)
        {
            try
            {
                Articulo articuloPorId = this._articuloPorId.FindById(id);
                LineaDTO linea = new LineaDTO { Articulo = articuloPorId, Cantidad = cantidad };
                if (_pedidoTemporal == null)
                {
                    _pedidoTemporal = new PedidoDTO { Lineas = new List<LineaDTO>() };
                }
                _pedidoTemporal.Lineas.Add(linea);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
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

