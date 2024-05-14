using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppLogic.DTOs;
using BusinessLogic.InterfacesRepositorio;
using BussinessLogic.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IRepositorioClientes _repositorioClientes;

        public ClienteController(IRepositorioClientes repositorioClientes)
        {
            this._repositorioClientes = repositorioClientes;
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

            }


            return View(this._repositorioClientes.FindAll());
        }



        public ActionResult FilterByName(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return RedirectToAction("Index", new { mensaje = "Escribe algo primero" });
            }

            TempData["word"] = word;
            return RedirectToAction("Index", new { filtro = "PorNombre" });

        }
    }
}

