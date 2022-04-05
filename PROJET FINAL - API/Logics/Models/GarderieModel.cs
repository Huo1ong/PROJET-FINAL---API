﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Logics.Models
{
    public class GarderieModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom de la garderie.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom de la garderie.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                if (value.Length <= 50)
                    nom = value;
                else
                    throw new Exception("Le nom de la Garderie doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant l'adresse de la garderie.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse de la garderie.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value.Length <= 100)
                    adresse = value;
                else
                    throw new Exception("L'adresse de la Garderie doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la ville de la garderie.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville de la garderie.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set
            {
                if (value.Length <= 75)
                    ville = value;
                else
                    throw new Exception("La ville de la garderie doit avoir un maximum de 75 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la province de la garderie.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province de la garderie.
        /// </summary>
        public string Province
        {
            get { return province; }
            set
            {
                if (value.Length <= 50)
                    province = value;
                else
                    throw new Exception("La province de la garderie doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le telephone de la garderie.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le telephone de la garderie.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("Le téléphone de la Garderie doit avoir un maximum de 12 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la liste de dépense de la garderie.
        /// </summary>
        private List<DepenseModel> listeDepense;
        /// <summary>
        /// Propriété représentant la liste de dépense de la garderie.
        /// </summary>
        public List<DepenseModel> ListeDepense
        {
            get { return listeDepense; }
            set
            {
                listeDepense = value;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré : GARDERIE
        /// </summary>
        /// <param name="unNom">Le nom de la garderie</param>
        /// <param name="uneAdresse">L'adresse de la garderie</param>
        /// <param name="uneVille">La ville de la garderie</param>
        /// <param name="uneProvince">La province de la garderie</param>
        /// <param name="unTelephone">Le téléphone de la garderie</param>
        public GarderieModel(string unNom = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
        {
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
        }

        #endregion Constructeurs

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Garderie.
        /// </summary>
        /// <returns>Version textuelle de l'objet Garderie.</returns>
        public override string ToString()
        {
            return Nom + "\n" + Adresse + "\n" + Ville + ", "
                    + Province + "\n" + "\n" + Telephone;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Garderie.
        /// Deux objets Garderie sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is GarderieModel) && Nom.Equals((obj as GarderieModel).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Garderie.
        /// </summary>
        /// <returns>HashCode de l'objet Garderie.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        /// <summary>
        /// Méthode permettant d'obtenir la liste des dépenses grâce au nom de la Garderie. 
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie</param>
        /// <returns>La liste des dépenses de la garderie</returns>
        public List<DepenseModel> ObtenirListeDepense(string nomGarderie)
        {
            return ListeDepense;
        }

        /// <summary>
        /// Méthode permettant d'ajouter une dépense dans la liste des dépenses de la Garderie. 
        /// </summary>
        /// <param name="depense">La nouvelle dépense à ajouter</param>
        /// <returns></returns>
        public void AjouterDepense(DepenseModel depense)
        {
            ListeDepense.Add(depense);
        }

        /// <summary>
        /// Méthode permettant de vérifier si une dépense est déjà présente dans la lite des dépenses de la Garderie.
        /// </summary>
        /// <param name="depense">La dépense à vérifier</param>
        /// <returns>TRUE si la dépense est présente / FALSE si elle n'est pas présente</returns>
        public bool SiDepensePresent(DepenseModel depense)
        {
            bool estPresent = false;

            foreach(DepenseModel dep in ListeDepense)
            {
                if(dep.DateTemps == depense.DateTemps)
                {
                    estPresent = true;
                }
            }

            return estPresent;
        }

        /// <summary>
        /// Méthode permettant d'obtenir le nombre de dépense dans la liste des dépenses de la Garderie.
        /// </summary>
        /// <returns>le nombre de dépense</returns>
        public int ObtenirNombreDepense()
        {
            return ListeDepense.Count;
        }

        /// <summary>
        /// Méthode permettant de vérifier si l'objet Garderie ne possède aucune dépense ou non.
        /// </summary>
        /// <returns>TRUE si aucune dépense / FALSE si une ou plusieurs dépense sont présentes</returns>
        public bool SiAucuneDepense()
        {
            if(ObtenirNombreDepense() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Overrides
    }
}
