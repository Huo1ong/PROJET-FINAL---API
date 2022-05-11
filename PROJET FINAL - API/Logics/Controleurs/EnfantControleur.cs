using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class EnfantControleur : Controller
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe EnfantControleur.
        /// </summary>
        private static EnfantControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EnfantControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EnfantControleur();
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
        private EnfantControleur() { }

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enfants.
        /// </summary>
        /// <returns>Liste contenant les enfants.</returns>
        public List<EnfantDTO> ObtenirListeEnfant()
        {
            List<EnfantDTO> listeEnfantDTO = EnfantRepository.Instance.ObtenirListeEnfant();
            List<EnfantModel> listeEnfant = new List<EnfantModel>();
            foreach (EnfantDTO enfant in listeEnfantDTO)
            {
                listeEnfant.Add(new EnfantModel(enfant.Nom, enfant.Prenom, enfant.DateDeNaissance, enfant.Adresse, enfant.Ville,enfant.Province, enfant.Telephone));
            }

            if (listeEnfant.Count == listeEnfantDTO.Count)
                return listeEnfantDTO;
            else
                throw new Exception("Erreur lors du chargement des Enfants, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir l'Enfant.
        /// </summary>
        /// <param name="nom">Le nom de l'Enfant.</param>
        /// <returns>Le DTO de l'Enfant.</returns>
        public EnfantDTO ObtenirEnfant(string nom)
        {
            EnfantDTO enfantDTO = EnfantRepository.Instance.ObtenirEnfant(nom);
            EnfantModel enfant = new EnfantModel(enfantDTO.Nom, enfantDTO.Prenom, enfantDTO.DateDeNaissance, enfantDTO.Adresse, enfantDTO.Ville, enfantDTO.Province, enfantDTO.Telephone);
            return new EnfantDTO(enfant);
        }

        /// <summary>
        /// Méthode de service permettant de créer la Enfant.
        /// </summary>
        /// <param name="enfantDTO">Le DTO de la Enfant.</param>
        public void AjouterEnfant(EnfantDTO enfantDTO)
        {
            bool OK = false;
            try
            {
                EnfantRepository.Instance.ObtenirIdEnfant(enfantDTO.Nom);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                EnfantRepository.Instance.AjouterEnfant(enfantDTO);
            }
            else
                throw new Exception("Erreur - L'Enfant est déjà existante.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier l'Enfant.
        /// </summary>
        /// <param name="enfantDTO">Le DTO de la Enfant.</param>
        public void ModifierEnfant(EnfantDTO enfantDTO)
        {
            EnfantDTO enfantDTO2 = ObtenirEnfant(enfantDTO.Nom);
            EnfantModel enfant = new EnfantModel(enfantDTO2.Nom, enfantDTO2.Prenom, enfantDTO2.DateDeNaissance, enfantDTO2.Adresse, enfantDTO2.Ville, enfantDTO2.Province, enfantDTO2.Telephone);

            if (enfantDTO.Adresse != enfant.Adresse || enfantDTO.Ville != enfant.Ville || enfantDTO.Province != enfant.Province || enfantDTO.Telephone != enfant.Telephone)
                EnfantRepository.Instance.ModifierEnfant(enfantDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer l'Enfant.
        /// </summary>
        /// <param name="nom">Le nom de l'Enfant.</param>
        public void SupprimerEnfant(string nom)
        {
            EnfantDTO enfantDTO = ObtenirEnfant(nom);
            EnfantRepository.Instance.SupprimerEnfant(enfantDTO);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Enfants.
        /// </summary>
        public void ViderListeEnfant()
        {
            if (ObtenirListeEnfant().Count == 0)
                throw new Exception("Erreur - La liste des Enfants est déjà vide.");
            EnfantRepository.Instance.ViderListeEnfant();
        }

        #endregion MethodesServices
    }
}
