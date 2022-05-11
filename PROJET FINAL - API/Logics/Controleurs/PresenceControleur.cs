using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;
using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Controllers;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class PresenceControleur {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe PresenceControleur.
        /// </summary>
        private static PresenceControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static PresenceControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new PresenceControleur();
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
        private PresenceControleur() { }

        #endregion Controleurs

        #region MethodesServices

        #region MethodesDepense

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Présences.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <returns>Liste contenant les Présences.</returns>
        public List<PresenceDTO> ObtenirListePresence(string nomGarderie)
        {
            GarderieDTO garderieDTO = GarderieRepository.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderieModel = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);

            List<PresenceDTO> listePresence = PresenceRepository.Instance.ObtenirListePresence(nomGarderie);
            foreach (PresenceDTO presence in listePresence)
            {
                garderieModel.AjouterPresence(new PresenceModel(presence.DateTemps));
            }

            if (garderieModel.ObtenirNombrePresence() == listePresence.Count)
                return listePresence;
            else
                throw new Exception("Erreur lors du chargement des présences, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une Présence.
        /// </summary>
        ///  <param name="nomGarderie">Nom de la Garderie</param>
        ///   <param name="date">Date de la Présence</param>
        /// <returns>Le DTO de la Présence désirée.</returns>
        public PresenceDTO ObtenirPresence(string nomGarderie, string date)
        {
            PresenceDTO presenceDTO = PresenceRepository.Instance.ObtenirPresence(nomGarderie, date);

            if (presenceDTO.DateTemps.Equals(date))
                return presenceDTO;
            else
                throw new Exception("Erreur lors de l'obtention de la présence, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une Présence.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        /// <param name="presenceDTO">Le DTO de la Présence a ajouter.</param>
        public void AjouterPresence(string nomGarderie, PresenceDTO presenceDTO)
        {
            presenceDTO.Enfant = EnfantRepository.Instance.ObtenirEnfant(presenceDTO.Enfant.Nom);
            presenceDTO.Educateur = EducateurRepository.Instance.ObtenirEducateur(presenceDTO.Educateur.Nom);

            PresenceRepository.Instance.AjouterPresence(nomGarderie, presenceDTO);
        }
        #endregion MethodesDepense

        #endregion MethodesServicess
    }
}
