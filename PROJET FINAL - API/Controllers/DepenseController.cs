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
        [Route("Depense/ObtenirListeDepense")]
        [HttpGet]
        public List<DepenseDTO> ObtenirListeDepartement(string nomGarderie)
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


        [Route("Depense/ObtenirDepense")]
        [HttpGet]
        public DepenseDTO ObtenirDepense([FromQuery] string nomGarderie, [FromQuery] string dateTemps)
        {
            DepenseDTO depense = new DepenseDTO(nomGarderie, dateTemps);
            try
            {
                depense = DepenseControleur.Instance.ObtenirDepense(nomGarderie, dateTemps);
            }
            catch (Exception ex)
            {
                depense = new DepenseDTO(nomGarderie, dateTemps);
            }
            return depense;
        }

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
    }
}
