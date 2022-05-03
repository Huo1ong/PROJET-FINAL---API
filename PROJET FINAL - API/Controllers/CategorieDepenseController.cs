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
        public CategorieDepenseDTO ObtenirCategorieDepense([FromQuery] string descriptionCategorieDepense)
        {
            CategorieDepenseDTO categorieDepense = new CategorieDepenseDTO();
            try
            {
                categorieDepense = CategorieDepenseControleur.Instance.ObtenirCategorieDepense(descriptionCategorieDepense);
            }
            catch (Exception ex)
            {
                categorieDepense = new CategorieDepenseDTO();
            }
            return categorieDepense;
        }

        /// <summary>
        /// Roles:
        ///  - Ajouter une CategorieDepense
        /// </summary>
        /// <param name="categorieDepenseDTO">La nouvelle CategorieDepense</param>
        /// <returns></returns>
        [Route("CategorieDepense/AjouterCategorieDepense")]
        [HttpPost]
        public void AjouterCategorieDepense([FromBody] CategorieDepenseDTO categorieDepenseDTO)
        {
            try
            {
                CategorieDepenseControleur.Instance.AjouterCategorieDepense(categorieDepenseDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Modifier une CategorieDepense
        /// </summary>
        /// <param name="categorieDepenseDTO">La CategorieDepense avec les nouvelles valeurs.</param>
        /// <returns</returns>
        [Route("CategorieDepense/ModifierCategorieDepense")]
        [HttpPost]
        public void ModifierCategorieDepense([FromBody] CategorieDepenseDTO categorieDepenseDTO)
        {
            try
            {
                CategorieDepenseControleur.Instance.ModifierCategorieDepense(categorieDepenseDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Supprimer une CategorieDepense grâce à sa description
        /// </summary>
        /// <param name="descriptionCategorieDepense">Description de la CategorieDepense</param>
        /// <returns></returns>
        [Route("CategorieDepense/SupprimerCategorieDepense")]
        [HttpPost]
        public void SupprimerCategorieDepense([FromQuery] string descriptionCategorieDepense)
        {
            try
            {
                CategorieDepenseControleur.Instance.SupprimerCategorieDepense(descriptionCategorieDepense);

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Vider la liste des CategoriesDepense
        /// </summary>
        /// <returns></returns>
        [Route("CategorieDepense/ViderListeCategorieDepense")]
        [HttpPost]
        public void ViderListeCategorieDepense()
        {
            try
            {
                CategorieDepenseControleur.Instance.ViderListeCategorieDepense();
            }
            catch (Exception ex)
            {

            }
            return;
        }
    }
}
