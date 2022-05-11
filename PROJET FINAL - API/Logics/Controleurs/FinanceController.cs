using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;
using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Controllers;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class FinanceControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe FinanceControleur.
        /// </summary>
        private static FinanceControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static FinanceControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new FinanceControleur();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Controleurs

        /// <summary>
        /// Constructeur par défaut de la classe.
        /// </summary>
        private FinanceControleur() { }

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Roles:
        ///  - Renvoie le total des revenus généré par la Garderie passé en paramètre
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne le revenu</returns>
        public double ObtenirRevenu(string nomGarderie)
        {
            // Nombre de Présence X 8$
            return PresenceControleur.Instance.ObtenirListePresence(nomGarderie).Count * 8;
        }

        /// <summary>
        /// Roles:
        ///  - Renvoie le total des dépenses généré par la Garderie passé en paramètre
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Retourne le total des Dépenses</returns>
        public double ObtenirDepenses(string nomGarderie)
        {
            
            double totalDA = 0;
            foreach (DepenseDTO depense in DepenseControleur.Instance.ObtenirListeDepense(nomGarderie))
            {
                totalDA = totalDA + depense.MontantAdmissible;
            }

            int nbEducateur = 0;
            int nbdate = 0;
            List<EducateurDTO> listeEducateur = EducateurControleur.Instance.ObtenirListeEducateur();
            Dictionary<EducateurDTO, string> listeDate = new Dictionary<EducateurDTO, string>();
            List<PresenceDTO> listePresence = PresenceControleur.Instance.ObtenirListePresence(nomGarderie);
            bool dejaAjouter = false;
            bool ajoutdate = false;

            foreach (PresenceDTO presence in listePresence) 
            {
                foreach (KeyValuePair<EducateurDTO, string> item in listeDate)
                {
                    if (ajoutdate == false)
                    {
                        if (presence.Educateur.Nom == item.Key.Nom && presence.Educateur.Prenom == item.Key.Prenom)
                        {
                            if (presence.DateTemps != item.Value)
                            {
                                nbdate++;
                                ajoutdate = true;
                            }
                            dejaAjouter = true;
                        }
                    }
                }
                if(ajoutdate == true)
                {
                    listeDate.Add(presence.Educateur, presence.DateTemps);
                    ajoutdate =false;
                }
                if (dejaAjouter == false)
                {
                    foreach (EducateurDTO educateur in listeEducateur)
                    {
                        if (dejaAjouter == false)
                        {
                            if (presence.Educateur.Nom == educateur.Nom && presence.Educateur.Prenom == educateur.Prenom)
                            {
                                nbEducateur++;
                                nbdate++;
                                listeDate.Add(presence.Educateur, presence.DateTemps);
                                dejaAjouter = true;
                            }
                        }
                    }
                }
                dejaAjouter = false;
            }

            double salaireEducateur = nbdate + nbEducateur * 8 * 18;

            // Total des dépenses admissibles + nbr de journées X nbr d’éducateurs.es X 8 heures X 18$(salaire)
            return totalDA + salaireEducateur;
        }
        #endregion MethodesServicess
    }
}

