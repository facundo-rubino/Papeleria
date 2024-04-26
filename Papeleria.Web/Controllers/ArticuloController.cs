﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BussinessLogic.Entidades;
using BussinessLogic.InterfacesRepositorio;
using AppLogic.DTOs;
using AppLogic.InterfacesCU.Articulos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Papeleria.Web.Controllers
{
    public class ArticuloController : Controller
    {
        private IAgregarArticulo _agregarArticuloCU;
        public IRepositorioArticulos _repositorioArticulos;
        public ArticuloController(IRepositorioArticulos repositorioArticulos, IAgregarArticulo agregarArticuloCU)
        {
            this._repositorioArticulos = repositorioArticulos;
            this._agregarArticuloCU = agregarArticuloCU;
        }
        // GET: ArticuloController
        public ActionResult Index()
        {
            return View(this._repositorioArticulos.FindAll());
            //return View();
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(this._repositorioArticulos.FindByID(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloDTO Articulo)
        {
            try
            {
                this._agregarArticuloCU.AgregarArticulo(Articulo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
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

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(this._repositorioArticulos.FindByID(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ArticuloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _repositorioArticulos.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

