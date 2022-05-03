using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Logics.Models
{
    public class EducateurModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom de l'Educateur.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom de l'Educateur.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                if (value.Length <= 50)
                    nom = value;
                else
                    throw new Exception("Le nom de l'Educateur doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le prenom de l'Educateur.
        /// </summary>
        private string prenom;
        /// <summary>
        /// Propriété représentant le prenom de l'Educateur.
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (value.Length <= 50)
                    prenom = value;
                else
                    throw new Exception("Le prenom de l'Educateur doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la date de naissance de l'Educateur.
        /// </summary>
        private string dateDeNaissance;
        /// <summary>
        /// Propriété représentant la date de naissance de l'Educateur.
        /// </summary>
        public string DateDeNaissance
        {
            get { return dateDeNaissance; }
            set
            {
                if (value.Length <= 50)
                    dateDeNaissance = value;
                else
                    throw new Exception("La date de naissance de l'Educateur doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant l'adresse de l'Educateur.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse de l'Educateur.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value.Length <= 100)
                    adresse = value;
                else
                    throw new Exception("L'adresse de l'Educateur doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la ville de l'Educateur.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville de l'Educateur.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set
            {
                if (value.Length <= 75)
                    ville = value;
                else
                    throw new Exception("La ville de l'enfant doit avoir un maximum de 75 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la province de l'Educateur.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province de l'Educateur.
        /// </summary>
        public string Province
        {
            get { return province; }
            set
            {
                if (value.Length <= 50)
                    province = value;
                else
                    throw new Exception("La province de l'Educateur doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le telephone de l'Educateur.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le telephone de l'Educateur.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("Le téléphone de l'Educateur doit avoir un maximum de 12 caractères.");
            }
        }


        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré : EDUCATEUR
        /// </summary>
        /// <param name="unNom">Le nom de l'Educateur</param>
        /// <param name="unPrenom">Le prenom de l'Educateur</param>
        /// <param name="uneDate">La date de naissance de l'Educateur</param>
        /// <param name="uneAdresse">L'adresse de l'Educateur</param>
        /// <param name="uneVille">La ville de l'Educateur</param>
        /// <param name="uneProvince">La province de l'Educateur</param>
        /// <param name="unTelephone">Le téléphone de l'Educateur</param>
        public EducateurModel(string unNom = "", string unPrenom = "", string uneDate = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
        {
            Nom = unNom;
            Prenom = unPrenom;
            DateDeNaissance = uneDate;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
        }

        #endregion Constructeurs

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Educateur.
        /// </summary>
        /// <returns>Version textuelle de l'objet Educateur.</returns>
        public override string ToString()
        {
            return Nom + "\n" + Prenom + "\n" + DateDeNaissance + "\n" + Adresse + "\n" + Ville + ", "
                    + Province + "\n" + Telephone;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Educateur.
        /// Deux objets Educateur sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is EducateurModel) && Nom.Equals((obj as EducateurModel).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Educateur.
        /// </summary>
        /// <returns>HashCode de l'objet Educateur.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
