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
            List<CategorieDepenseDTO> listeCategorieDepenseDTO = CategorieDepenseRepository.Instance.ObtenirListeCategorieDepense();
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
            CategorieDepenseDTO categorieDepenseDTO = CategorieDepenseRepository.Instance.ObtenirCategorieDepense(description);
            CategorieDepenseModel categorieDepense = new CategorieDepenseModel(categorieDepenseDTO.Description, categorieDepenseDTO.Pourcentage);
            return new CategorieDepenseDTO(categorieDepense);
        }

        /// <summary>
        /// Méthode de service permettant de créer le CategorieDepense.
        /// </summary>
        /// <param name="categorieDepense">Le DTO du CategorieDepense.</param>
        public void AjouterCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            bool OK = false;
            try
            {
                CategorieDepenseRepository.Instance.ObtenirIdCategorieDepense(categorieDepenseDTO.Description);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                CategorieDepenseModel uneCategorieDepense = new CategorieDepenseModel(categorieDepenseDTO.Description, categorieDepenseDTO.Pourcentage);
                CategorieDepenseRepository.Instance.AjouterCategorieDepense(categorieDepenseDTO);
            }
            else
                throw new Exception("Erreur - La CategorieDepense est déjà existant.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier la CategorieDepense
        /// <param name="categorieDepense">Le DTO de la CategorieDepense.</param>
        public void ModifierCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            CategorieDepenseDTO categorieDepenseDTO2 = ObtenirCategorieDepense(categorieDepenseDTO.Description);
            CategorieDepenseModel categorieDepense = new CategorieDepenseModel(categorieDepenseDTO2.Description, categorieDepenseDTO2.Pourcentage);

            if (categorieDepenseDTO.Pourcentage != categorieDepense.Pourcentage)
                CategorieDepenseRepository.Instance.ModifierCategorieDepense(categorieDepenseDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer le CategorieDepense.
        /// </summary>
        /// <param name="descriptionCategorieDepense">La description du CategorieDepense.</param>
        public void SupprimerCategorieDepense(string descriptionCategorieDepense)
        {
            CategorieDepenseDTO categorieDepenseDTO = ObtenirCategorieDepense(descriptionCategorieDepense);
            CategorieDepenseRepository.Instance.SupprimerCategorieDepense(categorieDepenseDTO);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des CategoriesDepense.
        /// </summary>
        public void ViderListeCategorieDepense()
        {
            if (ObtenirListeCategorieDepense().Count == 0)
                throw new Exception("Erreur - La liste des CategoriesDepense est déjà vide.");
            CategorieDepenseRepository.Instance.ViderListeCategorieDepense();
        }
        #endregion MethodesCategorieDepense

        #endregion MethodesServicess
    }
}
