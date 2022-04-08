using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;
using PROJET_FINAL___API.Logics.Controleurs;
using PROJET_FINAL___API.Controllers;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class DepenseControleur {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe DepenseControleur.
        /// </summary>
        private static DepenseControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static DepenseControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new DepenseControleur();
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
        private DepenseControleur() { }

        #endregion Controleurs

        #region MethodesServices

        #region MethodesDepense

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Dépenses.
        /// </summary>
        /// <param name="dateTemps">La date de la Dépense.</param>
        /// <returns>Liste contenant les Dépenses.</returns>
        public List<DepenseDTO> ObtenirListeDepense(string nomGarderie)
        {
            GarderieDTO garderieDTO = GarderieRepository.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderieModel = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);

            List<DepenseDTO> listeDepense = DepenseRepository.Instance.ObtenirListeDepense(nomGarderie);
            foreach (DepenseDTO depense in listeDepense)
            {
                CommerceModel commerceModel = new CommerceModel(depense.Commerce.Description, depense.Commerce.Adresse, depense.Commerce.Telephone);
                CategorieDepenseModel categorieDepenseModel = new CategorieDepenseModel(depense.Categorie.Description, depense.Categorie.Pourcentage);

                garderieModel.AjouterDepense(new DepenseModel(depense.DateTemps, depense.Montant, commerceModel, categorieDepenseModel));
            }

            if (garderieModel.ObtenirNombreDepense() == listeDepense.Count)
                return listeDepense;
            else
                throw new Exception("Erreur lors du chargement des dépenses, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une dépense.
        /// </summary>
        /// <param name="depense">Le DTO de la dépense désirée. (Informations du Equals nécessaires)</param>
        /// <returns>Le DTO de la dépense désirée.</returns>
        public DepenseDTO ObtenirDepense(string nomGarderie, string dateTemps)
        {
            DepenseDTO depenseDTO = DepenseRepository.Instance.ObtenirDepense(nomGarderie, dateTemps);

            if (depenseDTO.DateTemps.Equals(dateTemps + " 00:00:00"))
                return depenseDTO;
            else
                throw new Exception("Erreur lors de l'obtention de la dépense, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une dépense.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <param name="depense">Le DTO de la dépense a ajouter.</param>
        public void AjouterDepense(string nomGarderie, DepenseDTO depense)
        {
            GarderieDTO garderieDTO = GarderieRepository.Instance.ObtenirGarderie(nomGarderie);
            GarderieModel garderieModel = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);
            List<DepenseDTO> listeDepense = DepenseRepository.Instance.ObtenirListeDepense(nomGarderie);

            CommerceModel commerceModel = new CommerceModel(depense.Commerce.Description, depense.Commerce.Adresse, depense.Commerce.Telephone);
            CategorieDepenseModel categorieDepenseModel = new CategorieDepenseModel(depense.Categorie.Description, depense.Categorie.Pourcentage);
            foreach (DepenseDTO DepenseDTO in listeDepense)
            {
                garderieModel.AjouterDepense(new DepenseModel(depense.DateTemps, depense.Montant, commerceModel, categorieDepenseModel));
            }

            garderieModel.AjouterDepense(new DepenseModel(depense.DateTemps, depense.Montant, commerceModel, categorieDepenseModel));

            DepenseRepository.Instance.AjouterDepense(nomGarderie, depense);
        }

        #endregion MethodesDepense

        #endregion MethodesServicess

    }
}
