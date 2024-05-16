using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Clientes;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
using Microsoft.AspNetCore.Mvc;
using Papeleria.Web.Filters;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    [Logueado]
    public class ClienteController : Controller
    {
        private IRepositorioClientes _repositorioClientes;
        private IFiltroNombreCompleto _filtroNombreCompleto;

        public ClienteController(IRepositorioClientes repositorioClientes, IFiltroNombreCompleto filtroNombreCompleto)
        {
            this._repositorioClientes = repositorioClientes;
            this._filtroNombreCompleto = filtroNombreCompleto;

        }

        // GET: /<controller>/
        public IActionResult Index(string filtro)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return RedirectToAction("Login", new { mensaje = "Por favor logueate" });
            }

            IEnumerable<Cliente> aMostrar = new List<Cliente>();

            if (string.IsNullOrEmpty(filtro))
            {
                aMostrar = this._repositorioClientes.FindAll();
            }

            if (filtro == "PorNombre")
            {
                string nombre = (string)TempData["nombre"];
                aMostrar = this._filtroNombreCompleto.FiltrarPorNombreCompleto(nombre);
            }

            return View(aMostrar);
        }

        [HttpPost]
        public ActionResult FilterByName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return RedirectToAction("Index", new { mensaje = "Escribe algo primero" });
            }

            TempData["nombre"] = nombre;
            return RedirectToAction("Index", new { filtro = "PorNombre" });

        }


    }
}

