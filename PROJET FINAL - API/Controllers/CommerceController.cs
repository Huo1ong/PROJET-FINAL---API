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
            List<CommerceDTO> commerce;
            try
            {
                commerce = CommerceControleur.Instance.ObtenirListeCommerce();
            }
            catch (Exception)
            {
                commerce = new List<CommerceDTO>();
            }
            return commerce;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir un commerce grâce à sa description
        /// </summary>
        /// <param name="description">Description du Commerce</param>
        /// <returns>Retourne le commerce souhaité</returns>
        [Route("Commerce/ObtenirCommerce")]
        [HttpGet]
        public CommerceDTO ObtenirCommerce([FromQuery] string description)
        {
            CommerceDTO commerce = new CommerceDTO();
            try
            {
                commerce = CommerceControleur.Instance.ObtenirCommerce(description);
            }
            catch (Exception ex)
            {
                commerce = new CommerceDTO();
            }
            return commerce;
        }
    }
}