using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Usuarios;
using BussinessLogic.InterfacesRepositorio;
using BussinessLogic.Excepciones;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using BussinessLogic.Entidades;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private ILogin _loginUC;
        private IGetAllUsers _getAllUsersCU;
        private IAgregarUsuario _agregarUsuarioCU;
        private IRepositorioUsuarios _repositorioUsuarios;
        private IUpdateUser _updateUser;
        private IFindByEmail _findByEmailCU;
        private IBorrarUsuario _borrarUsuarioCU;


        public UsuarioController(
            IAgregarUsuario agregarUsuarioCU,
            ILogin loginUC,
            IUpdateUser updateUser,
            IRepositorioUsuarios repositorioUsuarios,
            IGetAllUsers getAllUsers,
            IFindByEmail findByEmail,
            IBorrarUsuario borrarUsuario
            )
        {
            this._agregarUsuarioCU = agregarUsuarioCU;
            this._loginUC = loginUC;
            this._updateUser = updateUser;
            this._repositorioUsuarios = repositorioUsuarios;
            this._getAllUsersCU = getAllUsers;
            this._findByEmailCU = findByEmail;
            this._borrarUsuarioCU = borrarUsuario;
        }

        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return RedirectToAction("Login", new { mensaje = "Por favor logueate" });
            }
            return View(this._getAllUsersCU.GetAllUsers());
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
                return View("Index", this._getAllUsersCU.GetAllUsers());
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
        public ActionResult Edit(string email)
        {
            try
            {
                return View(this._findByEmailCU.GetUserByEmail(email));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: usuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, UsuarioDTO usuario)
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
        public ActionResult Delete(string email)
        {
            try
            {
                return View(this._findByEmailCU.GetUserByEmail(email));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: usuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            this._borrarUsuarioCU.BorrarUsuario(Id);
            return RedirectToAction(nameof(Index));
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

