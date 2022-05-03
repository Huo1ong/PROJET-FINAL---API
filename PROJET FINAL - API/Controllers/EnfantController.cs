using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class EnfantController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des enfants
        /// </summary>
        /// <returns>Retourne la liste des enfants</returns>
        [Route("Enfant")]
        [Route("Enfant/ObtenirListeEnfant")]
        [HttpGet]
        public List<EnfantDTO> ObtenirListeEnfant()
        {
            List<EnfantDTO> liste;
            try
            {
                liste = EnfantControleur.Instance.ObtenirListeEnfant();
            }
            catch (Exception)
            {
                liste = new List<EnfantDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir un enfant grâce à son nom
        /// </summary>
        /// <param name="nomEnfant">Nom de l'Enfant</param>
        /// <returns>Retourne l'enfant souhaité</returns>
        [Route("Enfant/ObtenirEnfant")]
        [HttpGet]
        public EnfantDTO ObtenirEnfant([FromQuery] string nomEnfant)
        {
            EnfantDTO enfant = new EnfantDTO();
            try
            {
                enfant = EnfantControleur.Instance.ObtenirEnfant(nomEnfant);
            }
            catch (Exception ex)
            {
                enfant = new EnfantDTO();
            }
            return enfant;
        }

        /// <summary>
        /// Roles:
        ///  - Ajouter un enfant
        /// </summary>
        /// <param name="enfantDTO">La nouvelle Enfant</param>
        /// <returns></returns>
        [Route("Enfant/AjouterEnfant")]
        [HttpPost]
        public void AjouterEnfant([FromBody] EnfantDTO enfantDTO)
        {
            try
            {
                EnfantControleur.Instance.AjouterEnfant(enfantDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Modifier un Enfant
        /// </summary>
        /// <param name="enfantDTO">La enfant avec les nouvelles valeurs.</param>
        /// <returns</returns>
        [Route("Enfant/ModifierEnfant")]
        [HttpPost]
        public void ModifierEnfant([FromBody] EnfantDTO enfantDTO)
        {
            try
            {
                EnfantControleur.Instance.ModifierEnfant(enfantDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Supprimer un Enfant grâce à son nom
        /// </summary>
        /// <param name="nomEnfant">Nom de l'Enfant</param>
        /// <returns></returns>
        [Route("Enfant/SupprimerEnfant")]
        [HttpPost]
        public void SupprimerEnfant([FromQuery] string nomEnfant)
        {
            try
            {
                EnfantControleur.Instance.SupprimerEnfant(nomEnfant);

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Vider la liste des Enfants
        /// </summary>
        /// <returns></returns>
        [Route("Enfant/ViderListeEnfant")]
        [HttpPost]
        public void ViderListeEnfant()
        {
            try
            {
                EnfantControleur.Instance.ViderListeEnfant();
            }
            catch (Exception ex)
            {

            }
            return;
        }
    }
}
