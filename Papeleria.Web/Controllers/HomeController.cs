﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Papeleria.Web.Models;

namespace Papeleria.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
}

