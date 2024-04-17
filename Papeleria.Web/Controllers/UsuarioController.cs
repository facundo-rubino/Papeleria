using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppLogic.DTOs;
using AppLogic.InterfacesCU;
using BussinessLogic.Entidades;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IAgregarUsuario _agregarUsuarioCU;

        public UsuarioController(IAgregarUsuario agregarUsuarioCU)
        {
            this._agregarUsuarioCU = agregarUsuarioCU;
        }

        // GET: UsuarioController/Login
        [HttpGet]
        public IActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            try
            {
                //Usuario usuarioLogueado = _sistema.LoginUsuario(email, pass);
                HttpContext.Session.SetString("email", email);

                return View();


            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
            }
            return View();

        }


        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO usuario)
        {
            try
            {
                //Usuario usuarioLogueado = _sistema.LoginUsuario(email, pass);
                //HttpContext.Session.SetString("email", email);

                this._agregarUsuarioCU.AgregarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                // ViewBag.error = e.Message;
                return View();
            }
        }
    }
}

