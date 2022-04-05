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
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des garderies
        /// </summary>
        /// <returns>Retourne la liste des garderies</returns>
        [Route("")]
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

        /// <summary>
        /// Roles:
        ///  - Obtenir une garderie grâce à son nom
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne la garderie souhaité</returns>
        [Route("Garderie/ObtenirGarderie")]
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

        /// <summary>
        /// Roles:
        ///  - Ajouter une garderie
        /// </summary>
        /// <param name="garderieDTO">La nouvelle Garderie</param>
        /// <returns></returns>
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

        /// <summary>
        /// Roles:
        ///  - Modifier une garderie
        /// </summary>
        /// <param name="garderieDTO">La garderie avec les nouvelles valeurs.</param>
        /// <returns</returns>
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

        /// <summary>
        /// Roles:
        ///  - Supprimer une Garderie grâce à son nom
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns></returns>
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

        /// <summary>
        /// Roles:
        ///  - Vider la liste des garderies
        /// </summary>
        /// <returns></returns>
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
