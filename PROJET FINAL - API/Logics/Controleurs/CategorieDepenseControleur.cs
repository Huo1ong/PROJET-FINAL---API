using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class CategorieDepenseControleur {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe CategorieDepenseControleur.
        /// </summary>
        private static CategorieDepenseControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CategorieDepenseControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CategorieDepenseControleur();
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
        private CategorieDepenseControleur() { }

        #endregion Controleurs

        #region MethodesServices

        #region MethodesCategorieDepense

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Catégories de Dépense.
        /// </summary>
        /// <returns>Liste contenant les Catégories de Dépense.</returns>
        public List<CategorieDepenseDTO> ObtenirListeCategorieDepense()
        {
            List<CategorieDepenseDTO> listeCategorieDepenseDTO = CategorieDepenseDAO.Instance.ObtenirListeCategorieDepense();
            List<CategorieDepenseModel> listeCategorieDepense = new List<CategorieDepenseModel>();
            foreach (CategorieDepenseDTO categorieDepense in listeCategorieDepenseDTO)
            {
                listeCategorieDepense.Add(new CategorieDepenseModel(categorieDepense.Description, categorieDepense.Pourcentage));
            }

            if (listeCategorieDepense.Count == listeCategorieDepenseDTO.Count)
                return listeCategorieDepenseDTO;
            else
                throw new Exception("Erreur lors du chargement des Catégories de Dépense, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la Catégorie de Dépense.
        /// </summary>
        /// <param name="description">La description de la Catégorie de Dépense.</param>
        /// <returns>Le DTO de la Catégorie de Dépense.</returns>
        public CategorieDepenseDTO ObtenirCategorieDepense(string description)
        {
            CategorieDepenseDTO categorieDepenseDTO = CategorieDepenseDAO.Instance.ObtenirCategorieDepense(description);
            CategorieDepenseModel categorieDepense = new CategorieDepenseModel(categorieDepenseDTO.Description, categorieDepenseDTO.Telephone);
            return new CategorieDepenseDTO(categorieDepense);
        }

        #endregion MethodesCategorieDepense

        #endregion MethodesServicess
    }
}
