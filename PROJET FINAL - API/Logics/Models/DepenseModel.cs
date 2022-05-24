using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Logics.Models
{
    public class DepenseModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant la date et l'heure de la dépense.
        /// </summary>
        private string dateTemps;
        /// <summary>
        /// Propriété représentant la date et l'heure de la dépense.
        /// </summary>
        public string DateTemps
        {
            get { return dateTemps; }
            set
            {
                if (value.Length <= 50)
                    dateTemps = value;
                else
                    throw new Exception("La date et l'heure de la Dépense doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le montant de la dépense.
        /// </summary>
        private double montant;
        /// <summary>
        /// Propriété représentant le montant de la dépense.
        /// </summary>
        public double Montant
        {
            get { return montant; }
            set
            {
                if (value.ToString().Length <= 20)
                    montant = value;

                else
                {
                    throw new Exception("Le pourcentage de la categorie de depense doit avoir un maximum de 50 caractères.");
                }
            }
        }

        /// <summary>
        ///  Attribut représentant le commerce de la dépense.
        /// </summary>
        private CommerceModel commerce;
        /// <summary>
        ///  Propriété représentant le commerce de la dépense.
        /// </summary>
        public CommerceModel Commerce
        {
            get { return commerce; }
            set
            {
                commerce = value;
            }
        }

        /// <summary>
        ///  Attribut représentant la categorie de depense de la dépense.
        /// </summary>
        private CategorieDepenseModel categorie;
        /// <summary>
        ///  Propriété représentant la categorie de depense de la dépense.
        /// </summary>
        public CategorieDepenseModel Categorie
        {
            get { return categorie; }
            set
            {
                categorie = value;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré : DEPENSE
        /// </summary>
        /// <param name="uneDateTemps">La date et l'heure de la dépense</param>
        /// <param name="unMontant">Le montant de la dépense</param>
        /// <param name="unCommerce">Le commerce de la dépense</param>
        /// <param name="uneCategorie">Le categorie de la dépense</param>
        public DepenseModel(string uneDateTemps = "", double unMontant = 0, CommerceModel unCommerce = null, CategorieDepenseModel uneCategorie = null)
        {
            DateTemps = uneDateTemps;
            Montant = unMontant;
            Commerce = unCommerce;
            Categorie = uneCategorie;
        }

        #endregion Constructeurs

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Dépense.
        /// </summary>
        /// <returns>Version textuelle de l'objet Dépense.</returns>
        public override string ToString()
        {
            return DateTemps + "\n" + Montant + "\n" + Commerce.ToString() + "\n" + Categorie.ToString();
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Dépense.
        /// Deux objets Dépense sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is DepenseModel) && DateTemps.Equals((obj as DepenseModel).DateTemps);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Dépense.
        /// </summary>
        /// <returns>HashCode de l'objet Dépense.</returns>
        public override int GetHashCode()
        {
            return DateTemps.Length;
        }

        /// <summary>
        /// Méthode permettant d'obtenir la description de la catégorie de la dépense.
        /// </summary>
        /// <returns>la description de la catégorie de la dépense</returns>
        public string ObtenirCategorieDescription()
        {
            return Categorie.Description;
        }

        /// <summary>
        /// Méthode permettant d'obtenir le pourcentage de la catégorie de la dépense.
        /// </summary>
        /// <returns>le pourcentage de la catégorie de la dépense</returns>
        public double ObtenirCategoriePourcentage()
        {
            return Categorie.Pourcentage;
        }

        /// <summary>
        /// Méthode permettant de calculer la depense admissible. ( Montant * Pourcentage )
        /// </summary>
        /// <returns>La depense admissible</returns>
        public double CalculerDepenseAdmissible()
        {
            if(Categorie == null)
            {
                return 0;
            }
            else
            {
                return Montant * (0.01 * Categorie.Pourcentage);
            }
        }
        
        #endregion Overrides
    }
}
