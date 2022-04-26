using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PROJET_FINAL___API.Controllers
{
    public class CommerceController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des commerces
        /// </summary>
        /// <returns>Retourne la liste des commerces</returns>
        [Route("Commerce")]
        [Route("Commerce/ObtenirListeCommerce")]
        [HttpGet]
        public List<CommerceDTO> ObtenirListeCommerce()
        {
            List<CommerceDTO> listeCommerce;
            try
            {
                listeCommerce = CommerceControleur.Instance.ObtenirListeCommerce();
            }
            catch (Exception)
            {
                listeCommerce = new List<CommerceDTO>();
            }
            return listeCommerce;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir un commerce grâce à sa description
        /// </summary>
        /// <param name="description">Description du Commerce</param>
        /// <returns>Retourne le commerce souhaité</returns>
        [Route("Commerce/ObtenirCommerce")]
        [HttpGet]
        public CommerceDTO ObtenirCommerce([FromQuery] string descriptionCommerce)
        {
            CommerceDTO commerce = new CommerceDTO();
            try
            {
                commerce = CommerceControleur.Instance.ObtenirCommerce(descriptionCommerce);
            }
            catch (Exception ex)
            {
                commerce = new CommerceDTO();
            }
            return commerce;
        }

        /// <summary>
        /// Roles:
        ///  - Ajouter un Commerce
        /// </summary>
        /// <param name="commerceDTO">Le nouveau Commerce</param>
        /// <returns></returns>
        [Route("Commerce/AjouterCommerce")]
        [HttpPost]
        public void AjouterCommerce([FromBody] CommerceDTO commerceDTO)
        {
            try
            {
                CommerceControleur.Instance.AjouterCommerce(commerceDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Modifier un Commerce
        /// </summary>
        /// <param name="commerceDTO">Le Commerce avec les nouvelles valeurs.</param>
        /// <returns</returns>
        [Route("Commerce/ModifierCommerce")]
        [HttpPost]
        public void ModifierCommerce([FromBody] CommerceDTO commerceDTO)
        {
            try
            {
                CommerceControleur.Instance.ModifierCommerce(commerceDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Supprimer un Commerce grâce à sa description
        /// </summary>
        /// <param name="descriptionCommerce">Description du Commerce</param>
        /// <returns></returns>
        [Route("Commerce/SupprimerCommerce")]
        [HttpPost]
        public void SupprimerCommerce([FromQuery] string descriptionCommerce)
        {
            try
            {
                CommerceControleur.Instance.SupprimerCommerce(descriptionCommerce);

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Vider la liste des Commerces
        /// </summary>
        /// <returns></returns>
        [Route("Commerce/ViderListeCommerce")]
        [HttpPost]
        public void ViderListeCommerce()
        {
            try
            {
                CommerceControleur.Instance.ViderListeCommerce();
            }
            catch (Exception ex)
            {

            }
            return;
        }
    }
}