using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class GarderieControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe GarderieControleur.
        /// </summary>
        private static GarderieControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static GarderieControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new GarderieControleur();
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
        private GarderieControleur() { }

        #endregion Controleurs

        #region MethodesServices

        #region MethodesGarderie

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des garderies.
        /// </summary>
        /// <returns>Liste contenant les garderies.</returns>
        public List<GarderieDTO> ObtenirListeGarderie()
        {
            List<GarderieDTO> listeGarderieDTO = GarderieDAO.Instance.ObtenirListeGarderie();
            List<GarderieModel> listeGarderie = new List<GarderieModel>();
            foreach (GarderieDTO garderie in listeGarderieDTO)
            {
                listeGarderie.Add(new GarderieModel(garderie.Nom, garderie.Adresse, garderie.Ville, garderie.Province, garderie.Telephone));
            }

            if (listeGarderie.Count == listeGarderieDTO.Count)
                return listeGarderieDTO;
            else
                throw new Exception("Erreur lors du chargement des Garderies, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la Garderie.
        /// </summary>
        /// <param name="nom">Le nom de la Garderie.</param>
        /// <returns>Le DTO de le Garderie.</returns>
        public GarderieDTO ObtenirGarderie(string nom)
        {
            GarderieDTO garderieDTO = GarderieDAO.Instance.ObtenirGarderie(nom);
            GarderieModel garderie = new GarderieModel(garderieDTO.Nom, garderieDTO.Adresse, garderieDTO.Ville, garderieDTO.Province, garderieDTO.Telephone);
            return new GarderieDTO(garderie);
        }

        /// <summary>
        /// Méthode de service permettant de créer la Garderie.
        /// </summary>
        /// <param name="garderie">Le DTO de la Garderie.</param>
        public void AjouterGarderie(GarderieDTO garderie)
        {
            bool OK = false;
            try
            {
                GarderieDAO.Instance.ObtenirIdGarderie(garderie.Nom);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                GarderieModel uneGarderie = new GarderieModel(garderie.Nom, garderie.Adresse, garderie.Ville, garderie.Province, garderie.Telephone);
                GarderieDAO.Instance.AjouterGarderie(garderie);
            }
            else
                throw new Exception("Erreur - La Garderie est déjà existante.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier la Garderie.
        /// </summary>
        /// <param name="garderie">Le DTO de la Garderie.</param>
        public void ModifierGarderie(GarderieDTO garderieDTO)
        {
            GarderieDTO garderieDTO2 = ObtenirGarderie(garderieDTO.Nom);
            GarderieModel garderie = new GarderieModel(garderieDTO2.Nom, garderieDTO2.Adresse, garderieDTO2.Ville, garderieDTO2.Province, garderieDTO2.Telephone);

            if (garderieDTO.Adresse != garderie.Adresse || garderieDTO.Ville != garderie.Ville || garderieDTO.Province != garderie.Province || garderieDTO.Telephone != garderie.Telephone)
                GarderieDAO.Instance.ModifierGarderie(garderieDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer la Garderie.
        /// </summary>
        /// <param name="garderie">Le nom de la Garderie.</param>
        public void SupprimerGarderie(string nom)
        {
            GarderieDTO garderieDTO= ObtenirGarderie(nom);
            GarderieDAO.Instance.SupprimerGarderie(garderieDTO);
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Garderies.
        /// </summary>
        public void ViderListeGarderie()
        {
            if (ObtenirListeGarderie().Count == 0)
                throw new Exception("Erreur - La liste des Garderies est déjà vide.");
            GarderieDAO.Instance.ViderListeGarderie();
        }

        #endregion MethodesGarderie

        #endregion MethodesServices
    }
}
