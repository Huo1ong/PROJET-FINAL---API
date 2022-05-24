using Microsoft.AspNetCore.Mvc;
using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using System;
using System.Collections.Generic;

namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class PresenceController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des Présences
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne la liste des Présences</returns>
        [Route("Presence/ObtenirListePresence")]
        [HttpGet]
        public List<PresenceDTO> ObtenirListePresence(string nomGarderie)
        {
            List<PresenceDTO> listePresence;
            try
            {
                listePresence = PresenceControleur.Instance.ObtenirListePresence(nomGarderie);
            }
            catch (Exception)
            {
                listePresence = new List<PresenceDTO>();
            }
            return listePresence;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir une Présence grâce à sa date et le nom de la Garderie
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="date">Date de la Présence</param>
        /// <returns>Retourne la présence souhaitée</returns>
        [Route("Presence/ObtenirPresence")]
        [HttpGet]
        public PresenceDTO ObtenirPresence([FromQuery] string nomGarderie, [FromQuery] string date)
        {
            PresenceDTO presence = new PresenceDTO();
            try
            {
                presence = PresenceControleur.Instance.ObtenirPresence(nomGarderie, date);
            }
            catch (Exception ex)
            {
                presence = new PresenceDTO();
            }
            return presence;
        }

        /// <summary>
        /// Roles:
        ///  - Ajouter une Présence
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="presenceDTO">La nouvelle Présence</param>
        /// <returns></returns>
        [Route("Presence/AjouterPresence")]
        [HttpPost]
        public void AjouterPresence([FromQuery] string nomGarderie, [FromBody] PresenceDTO presenceDTO)
        {
            try
            {
                PresenceControleur.Instance.AjouterPresence(nomGarderie, presenceDTO);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
