using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class EducateurController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des Educateurs
        /// </summary>
        /// <returns>Retourne la liste des Educateurs</returns>
        [Route("Educateur")]
        [Route("Educateur/ObtenirListeEducateur")]
        [HttpGet]
        public List<EducateurDTO> ObtenirListeEducateur()
        {
            List<EducateurDTO> liste;
            try
            {
                liste = EducateurControleur.Instance.ObtenirListeEducateur();
            }
            catch (Exception)
            {
                liste = new List<EducateurDTO>();
            }
            return liste;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir un Educateur grâce à son nom
        /// </summary>
        /// <param name="nomEducateur">Nom de l'Educateur</param>
        /// <returns>Retourne l'Educateur souhaité</returns>
        [Route("Educateur/ObtenirEducateur")]
        [HttpGet]
        public EducateurDTO ObtenirEducateur([FromQuery] string nomEducateur)
        {
            EducateurDTO Educateur = new EducateurDTO();
            try
            {
                Educateur = EducateurControleur.Instance.ObtenirEducateur(nomEducateur);
            }
            catch (Exception ex)
            {
                Educateur = new EducateurDTO();
            }
            return Educateur;
        }

        /// <summary>
        /// Roles:
        ///  - Ajouter un Educateur
        /// </summary>
        /// <param name="EducateurDTO">La nouvelle Educateur</param>
        /// <returns></returns>
        [Route("Educateur/AjouterEducateur")]
        [HttpPost]
        public void AjouterEducateur([FromBody] EducateurDTO EducateurDTO)
        {
            try
            {
                EducateurControleur.Instance.AjouterEducateur(EducateurDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Modifier un Educateur
        /// </summary>
        /// <param name="EducateurDTO">La Educateur avec les nouvelles valeurs.</param>
        /// <returns</returns>
        [Route("Educateur/ModifierEducateur")]
        [HttpPost]
        public void ModifierEducateur([FromBody] EducateurDTO EducateurDTO)
        {
            try
            {
                EducateurControleur.Instance.ModifierEducateur(EducateurDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Supprimer un Educateur grâce à son nom
        /// </summary>
        /// <param name="nomEducateur">Nom de l'Educateur</param>
        /// <returns></returns>
        [Route("Educateur/SupprimerEducateur")]
        [HttpPost]
        public void SupprimerEducateur([FromQuery] string nomEducateur)
        {
            try
            {
                EducateurControleur.Instance.SupprimerEducateur(nomEducateur);

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Vider la liste des Educateurs
        /// </summary>
        /// <returns></returns>
        [Route("Educateur/ViderListeEducateur")]
        [HttpPost]
        public void ViderListeEducateur()
        {
            try
            {
                EducateurControleur.Instance.ViderListeEducateur();
            }
            catch (Exception ex)
            {

            }
            return;
        }
    }
}
