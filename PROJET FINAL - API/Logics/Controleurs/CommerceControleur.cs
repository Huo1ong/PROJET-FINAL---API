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

        /// <summary>
        /// Méthode de service permettant de créer le Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du Commerce.</param>
        public void AjouterCommerce(CommerceDTO commerceDTO)
        {
            bool OK = false;
            try
            {
                CommerceRepository.Instance.ObtenirIdCommerce(commerceDTO.Description);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                CommerceRepository.Instance.AjouterCommerce(commerceDTO);
            }
            else
                throw new Exception("Erreur - Le Commerce est déjà existant.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier le Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du Commerce.</param>
        public void ModifierCommerce(CommerceDTO commerceDTO)
        {
            CommerceDTO commerceDTO2 = ObtenirCommerce(commerceDTO.Description);
            CommerceModel commerce = new CommerceModel(commerceDTO2.Description, commerceDTO2.Adresse, commerceDTO2.Telephone);

            if (commerceDTO.Adresse != commerce.Adresse || commerceDTO.Telephone != commerce.Telephone)
                CommerceRepository.Instance.ModifierCommerce(commerceDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer le Commerce.
        /// </summary>
        /// <param name="descriptionCommerce">La description du Commerce.</param>
        public void SupprimerCommerce(string descriptionCommerce)
        {
            CommerceDTO commerceDTO = ObtenirCommerce(descriptionCommerce);
            CommerceRepository.Instance.SupprimerCommerce(commerceDTO);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Commerces.
        /// </summary>
        public void ViderListeCommerce()
        {
            if (ObtenirListeCommerce().Count == 0)
                throw new Exception("Erreur - La liste des Commerces est déjà vide.");
            CommerceRepository.Instance.ViderListeCommerce();
        }

        #endregion MethodesServices
    }
}
