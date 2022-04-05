using Microsoft.AspNetCore.Mvc;
using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using System;
using System.Collections.Generic;

namespace PROJET_FINAL___API.Controllers
{
    public class DepenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
