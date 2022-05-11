using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Logics.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PROJET_FINAL___API.Controllers
{
    [ApiController]
    public class FinanceController : Controller
    {
        /// <summary>
        /// Roles:
        ///  - Renvoie le total des revenus généré par la Garderie passé en paramètre
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne le revenu</returns>
        [Route("Finance/ObtenirRevenu")]
        [HttpGet]
        public double ObtenirRevenu(string nomGarderie)
        {
            return FinanceControleur.Instance.ObtenirRevenu(nomGarderie);
        }

        /// <summary>
        /// Roles:
        ///  - Renvoie le total des dépenses généré par la Garderie passé en paramètre
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne le total des Dépenses</returns>
        [Route("Finance/ObtenirDepenses")]
        [HttpGet]
        public double ObtenirDepenses(string nomGarderie)
        {
            return FinanceControleur.Instance.ObtenirDepenses(nomGarderie);
        }
    }
}
