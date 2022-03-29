using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Controllers
{
    public class GarderieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
