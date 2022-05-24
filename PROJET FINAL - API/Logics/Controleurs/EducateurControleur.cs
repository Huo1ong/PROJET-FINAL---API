using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class EducateurControleur : Controller
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe EducateurControleur.
        /// </summary>
        private static EducateurControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EducateurControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EducateurControleur();
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
        private EducateurControleur() { }

        #endregion Controleurs

        #region MethodesServices

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Educateurs.
        /// </summary>
        /// <returns>Liste contenant les Educateurs.</returns>
        public List<EducateurDTO> ObtenirListeEducateur()
        {
            List<EducateurDTO> listeEducateurDTO = EducateurRepository.Instance.ObtenirListeEducateur();
            List<EducateurModel> listeEducateur = new List<EducateurModel>();
            foreach (EducateurDTO Educateur in listeEducateurDTO)
            {
                listeEducateur.Add(new EducateurModel(Educateur.Nom, Educateur.Prenom, Educateur.DateDeNaissance, Educateur.Adresse, Educateur.Ville, Educateur.Province, Educateur.Telephone));
            }

            if (listeEducateur.Count == listeEducateurDTO.Count)
                return listeEducateurDTO;
            else
                throw new Exception("Erreur lors du chargement des Educateurs, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir l'Educateur.
        /// </summary>
        /// <param name="nom">Le nom de l'Educateur.</param>
        /// <returns>Le DTO de l'Educateur.</returns>
        public EducateurDTO ObtenirEducateur(string nom)
        {
            EducateurDTO EducateurDTO = EducateurRepository.Instance.ObtenirEducateur(nom);
            EducateurModel Educateur = new EducateurModel(EducateurDTO.Nom, EducateurDTO.Prenom, EducateurDTO.DateDeNaissance, EducateurDTO.Adresse, EducateurDTO.Ville, EducateurDTO.Province, EducateurDTO.Telephone);
            return new EducateurDTO(Educateur);
        }

        /// <summary>
        /// Méthode de service permettant de créer la Educateur.
        /// </summary>
        /// <param name="EducateurDTO">Le DTO de la Educateur.</param>
        public void AjouterEducateur(EducateurDTO EducateurDTO)
        {
            bool OK = false;
            try
            {
                EducateurRepository.Instance.ObtenirIdEducateur(EducateurDTO.Nom);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                EducateurRepository.Instance.AjouterEducateur(EducateurDTO);
            }
            else
                throw new Exception("Erreur - L'Educateur est déjà existante.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier l'Educateur.
        /// </summary>
        /// <param name="EducateurDTO">Le DTO de la Educateur.</param>
        public void ModifierEducateur(EducateurDTO EducateurDTO)
        {
            EducateurDTO EducateurDTO2 = ObtenirEducateur(EducateurDTO.Nom);
            EducateurModel Educateur = new EducateurModel(EducateurDTO2.Nom, EducateurDTO2.Prenom, EducateurDTO2.DateDeNaissance, EducateurDTO2.Adresse, EducateurDTO2.Ville, EducateurDTO2.Province, EducateurDTO2.Telephone);

            if (EducateurDTO.Adresse != Educateur.Adresse || EducateurDTO.Ville != Educateur.Ville || EducateurDTO.Province != Educateur.Province || EducateurDTO.Telephone != Educateur.Telephone)
                EducateurRepository.Instance.ModifierEducateur(EducateurDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer l'Educateur.
        /// </summary>
        /// <param name="nom">Le nom de l'Educateur.</param>
        public void SupprimerEducateur(string nom)
        {
            EducateurDTO EducateurDTO = ObtenirEducateur(nom);
            EducateurRepository.Instance.SupprimerEducateur(EducateurDTO);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Educateurs.
        /// </summary>
        public void ViderListeEducateur()
        {
            if (ObtenirListeEducateur().Count == 0)
                throw new Exception("Erreur - La liste des Educateurs est déjà vide.");
            EducateurRepository.Instance.ViderListeEducateur();
        }

        #endregion MethodesServices
    }
}
