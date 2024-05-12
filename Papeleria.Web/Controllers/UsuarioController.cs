using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using BussinessLogic.InterfacesRepositorio;
using BussinessLogic.Excepciones;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private ILogin _loginUC;
        private IAgregarUsuario _agregarUsuarioCU;
        private IRepositorioUsuarios _repositorioUsuarios;
        private IUpdateUser _updateUser;

        public UsuarioController(
            IAgregarUsuario agregarUsuarioCU,
            ILogin loginUC,
            IUpdateUser updateUser,
            IRepositorioUsuarios repositorioUsuarios)
        {
            this._agregarUsuarioCU = agregarUsuarioCU;
            this._loginUC = loginUC;
            this._updateUser = updateUser;
            this._repositorioUsuarios = repositorioUsuarios;
        }

        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return RedirectToAction("Login", new { mensaje = "Por favor logueate" });
            }
            return View(this._repositorioUsuarios.FindAll());
            //return View("Index");
        }

        // GET: UsuarioController/Login
        public IActionResult Login(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            if (_loginUC.LoginIsValid(email, pass))
            {
                HttpContext.Session.SetString("email", email);
                ViewBag.email = email;
                return View("Index", this._repositorioUsuarios.FindAll());
            }
            return RedirectToAction("Login", new { error = "email o contraseña incorrectos" });
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
                this._agregarUsuarioCU.AgregarUsuario(usuario);
                return RedirectToAction("Login", new { mensaje = "Usuario creado" });
            }
            catch (UsuarioNoValidoException ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }
        // GET: usuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(this._repositorioUsuarios.FindByID(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: usuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioDTO usuario)
        {
            try
            {
                this._updateUser.UpdateUser(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: usuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(this._repositorioUsuarios.FindByID(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: usuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _repositorioUsuarios.Remove(id);
            return View(Index);
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

