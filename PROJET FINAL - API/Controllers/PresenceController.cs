using Microsoft.AspNetCore.Mvc;
using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using System;
using System.Collections.Generic;

namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class DepenseController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Obtenir la liste des Dépenses
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne la liste des Dépenses</returns>
        [Route("Depense/ObtenirListeDepense")]
        [HttpGet]
        public List<DepenseDTO> ObtenirListeDepense(string nomGarderie)
        {
            List<DepenseDTO> listeDepense;
            try
            {
                listeDepense = DepenseControleur.Instance.ObtenirListeDepense(nomGarderie);
            }
            catch (Exception)
            {
                listeDepense = new List<DepenseDTO>();
            }
            return listeDepense;
        }

        /// <summary>
        /// Roles:
        ///  - Obtenir une Dépense grâce à sa date et le nom de la Garderie
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="dateTemps">Date de la Dépense</param>
        /// <returns>Retourne la garderie souhaité</returns>
        [Route("Depense/ObtenirDepense")]
        [HttpGet]
        public DepenseDTO ObtenirDepense([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            DepenseDTO depense = new DepenseDTO();
            try
            {
                depense = DepenseControleur.Instance.ObtenirDepense(nomGarderie, dateTemps);
            }
            catch (Exception ex)
            {
                depense = new DepenseDTO();
            }
            return depense;
        }

        /// <summary>
        /// Roles:
        ///  - Ajouter une Dépense
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="depenseDTO">La nouvelle Dépense</param>
        /// <returns></returns>
        [Route("Depense/AjouterDepense")]
        [HttpPost]
        public void AjouterDepense([FromQuery] string nomGarderie, [FromBody] DepenseDTO depenseDTO)
        {
            try
            {
                DepenseControleur.Instance.AjouterDepense(nomGarderie, depenseDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Modifier une garderie
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="depenseDTO">La Dépense avec de nouvelles valeurs</param>
        /// <returns</returns>
        [Route("Depense/ModifierDepense")]
        [HttpPost]
        public void ModifierDepense([FromQuery] string nomGarderie, [FromBody] DepenseDTO depenseDTO)
        {
            try
            {
                DepenseControleur.Instance.ModifierDepense(nomGarderie, depenseDTO);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Supprimer une Dépense grâce à sa date et le nom de la Garderie
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="dateTemps">Date de la Dépense</param>
        /// <returns></returns>
        [Route("Depense/SupprimerDepense")]
        [HttpPost]
        public void SupprimerDepense([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            try
            {
                DepenseControleur.Instance.SupprimerDepense(nomGarderie, dateTemps);

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Roles:
        ///  - Vider la liste des dépenses
        /// </summary>
        /// <returns></returns>
        [Route("Depense/ViderListeDepense")]
        [HttpPost]
        public void ViderListeDepartement([FromQuery] string nomGarderie)
        {
            try
            {
                DepenseControleur.Instance.ViderListeDepense(nomGarderie);
            }
            catch (Exception ex)
            {

            }
            return;
        }
    }
}
