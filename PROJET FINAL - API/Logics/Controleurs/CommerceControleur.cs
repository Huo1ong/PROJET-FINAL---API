using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class CommerceControleur {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe CommerceControleur.
        /// </summary>
        private static CommerceControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CommerceControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CommerceControleur();
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
        private CommerceControleur() { }

        #endregion Controleurs

        #region MethodesServices

        #region MethodesCommerce

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des commerces.
        /// </summary>
        /// <returns>Liste contenant les commerces.</returns>
        public List<CommerceDTO> ObtenirListeCommerce()
        {
            List<CommerceDTO> listeCommerceDTO = CommerceRepository.Instance.ObtenirListeCommerce();
            List<CommerceModel> listeCommerce = new List<CommerceModel>();
            foreach (CommerceDTO commerce in listeCommerceDTO)
            {
                listeCommerce.Add(new CommerceModel(commerce.Description, commerce.Adresse, commerce.Telephone));
            }

            if (listeCommerce.Count == listeCommerceDTO.Count)
                return listeCommerceDTO;
            else
                throw new Exception("Erreur lors du chargement des Commerces, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le Commerce.
        /// </summary>
        /// <param name="description">La description du Commerce.</param>
        /// <returns>Le DTO du Commerce.</returns>
        public CommerceDTO ObtenirCommerce(string description)
        {
            CommerceDTO commerceDTO = CommerceRepository.Instance.ObtenirCommerce(description);
            CommerceModel commerce = new CommerceModel(commerceDTO.Description, commerceDTO.Adresse, commerceDTO.Telephone);
            return new CommerceDTO(commerce);
        }

        #endregion MethodesCommerce

        #endregion MethodesServicess
    }
}
