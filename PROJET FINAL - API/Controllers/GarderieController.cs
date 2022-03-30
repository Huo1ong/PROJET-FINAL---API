using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
            List<GarderieDTO> liste;
            try
            {
                liste = GarderieControleur.Instance.ObtenirListeGarderie();
            }
            catch (Exception)
            {
                liste = new List<GarderieDTO>();
            }
            return liste;
        }

        [Route("Garderie/ObtenirGaderie")]
        [HttpGet]
        public GarderieDTO ObtenirGarderie([FromQuery] string nomGarderie)
        {
            GarderieDTO garderie = new GarderieDTO();
            try
            {
                garderie = GarderieControleur.Instance.ObtenirGarderie(nomGarderie);
            }
            catch (Exception ex)
            {
                garderie = new GarderieDTO();
            }
            return garderie;
        }

        [Route("Garderie/AjouterGarderie")]
        [HttpPost]
        public void AjouterGarderie([FromBody] GarderieDTO garderieDTO)
        {
            try
            {
                GarderieControleur.Instance.AjouterGarderie(garderieDTO);
            }
            catch (Exception ex)
            {

            }
        }

        [Route("Garderie/ModifierGarderie")]
        [HttpPost]
        public void ModifierGarderie([FromBody] GarderieDTO garderieDTO)
        {
            try
            {
                GarderieControleur.Instance.ModifierGarderie(garderieDTO);
            }
            catch (Exception ex)
            {

            }
        }

        [Route("Garderie/SupprimerGarderie")]
        [HttpPost]
        public void SupprimerGarderie([FromQuery] string nomGarderie)
        {
            try
            {
                GarderieControleur.Instance.SupprimerGarderie(nomGarderie);

            }
            catch (Exception ex)
            {

            }
        }

        [Route("Garderie/ViderListeGarderie")]
        [HttpPost]
        public void ViderListeGarderie()
        {
            try
            {
                GarderieControleur.Instance.ViderListeGarderie();
            }
            catch (Exception ex)
            {

            }
            return;
        }
    }
}
