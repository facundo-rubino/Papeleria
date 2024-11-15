﻿using System;
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
using Papeleria.Web.Filters;

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
                return RedirectToAction("Login", new { error = "Por favor logueate" });
            }
            return View(this._getAllUsersCU.GetAllUsers());
            //return View("Index");
        }

        // GET: UsuarioController/Login
        public IActionResult Login(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            try
            {
                if (_loginUC.LoginIsValid(email, pass))
                {
                    HttpContext.Session.SetString("email", email);
                    ViewBag.email = email;
                    return View("Index", this._getAllUsersCU.GetAllUsers());
                }
                else
                {
                    throw new UsuarioNoValidoException("Email y/o contraseña incorrectos");
                }

            }
            catch (UsuarioNoValidoException ex)
            {
                ViewBag.error = ex.Message;
                return View("Login");
            }
        }


        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View(new UsuarioDTO());
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO usuario)
        {
            try
            {
                this._agregarUsuarioCU.AgregarUsuario(usuario);
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
                {
                    return RedirectToAction("Login", new { Mensaje = "Usuario creado correctamente" });
                }
                else
                {
                    return RedirectToAction(nameof(Index), new { Mensaje = "Usuario creado correctamente" });
                }

            }
            catch (UsuarioNoValidoException ex)
            {
                ViewBag.error = ex.Message;
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(usuario);
            }
        }
        // GET: usuarioController/Edit/5
        [Logueado]
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
        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, UsuarioDTO usuario)
        {
            try
            {
                this._updateUser.UpdateUser(usuario);
                ViewBag.Mensaje = "Usuario actualizado exitosamente";
                return View("Index", this._getAllUsersCU.GetAllUsers());
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: usuarioController/Delete/5
        [Logueado]
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
        [Logueado]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            this._borrarUsuarioCU.BorrarUsuario(Id);
            if (this._repositorioUsuarios.FindAll().Count() == 0)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}

