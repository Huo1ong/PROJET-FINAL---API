using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class GarderieController : Controller
    {
        [Route("Garderie")]
        [Route("Garderie/ObtenirListeGarderie")]
        [HttpGet]
        public List<GarderieDTO> ObtenirListeGarderie()
        {
            return null;
        }

        [Route("Garderie/ObtenirGaderie")]
        [HttpGet]
        public GarderieDTO ObtenirGarderie()
        {
            return null;
        }

        [Route("Garderie/AjouterGarderie")]
        [HttpPost]
        public void AjouterGarderie()
        {

        }

        [Route("Garderie/ModifierGarderie")]
        [HttpPost]
        public void ModifierGarderie()
        {

        }

        [Route("Garderie/SupprimerGarderie")]
        [HttpPost]
        public void SupprimerGarderie()
        {

        }

        [Route("Garderie/ViderListeGarderie")]
        [HttpPost]
        public void ViderListeGarderie()
        {

        }
    }
}