using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class CategorieDepenseController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des catégories de dépense
        /// </summary>
        /// <returns>Retourne la liste des catégories de dépense</returns>
        [Route("CategorieDepense")]
        [Route("CategorieDepense/ObtenirListeCategorieDepense")]
        [HttpGet]
        public List<CategorieDepenseDTO> ObtenirListeCategorieDepense()
        {
            List<CategorieDepenseDTO> listeCategorieDepense;
            try
            {
                listeCategorieDepense = CategorieDepenseControleur.Instance.ObtenirListeCategorieDepense();
            }
            catch (Exception)
            {
                listeCategorieDepense = new List<CategorieDepenseDTO>();
            }
            return listeCategorieDepense;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir une catégorie de dépense grâce à sa description
        /// </summary>
        /// <param name="description">Description de la Catégorie de dépenses</param>
        /// <returns>Retourne la catégorie de dépense souhaitée</returns>
        [Route("CategorieDepense/ObtenirCategorieDepense")]
        [HttpGet]
        public CategorieDepenseDTO ObtenirCategorieDepense([FromQuery] string description)
        {
            CategorieDepenseDTO categorieDepense = new CategorieDepenseDTO();
            try
            {
                categorieDepense = CategorieDepenseControleur.Instance.ObtenirCategorieDepense(description);
            }
            catch (Exception ex)
            {
                categorieDepense = new CategorieDepenseDTO();
            }
            return categorieDepense;
        }
    }
}
