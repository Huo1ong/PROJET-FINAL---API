using PROJET_FINAL___API.Logics.Models;
using System;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class DepenseDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la date et l'heure de la Depense.
        /// </summary>
        public string DateTemps { get; set; }
        /// <summary>
        /// Propriété représentant le montant de la Depense.
        /// </summary>
        public double Montant { get; set; }
        /// <summary>
        /// Propriété représentant le montant admissible de la Depense.
        /// </summary>
        public double MontantAdmissible { get; set; }
        /// <summary>
        /// Propriété représentant le commerce de la Depense.
        /// </summary>
        public CommerceDTO Commerce { get; set; }
        /// <summary>
        /// Propriété représentant la catégorie de la Depense.
        /// </summary>
        public CategorieDepenseDTO Categorie { get; set; }

        #endregion Proprietes

        #region Constructeurs

        public DepenseDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="dateTemps">Date et Heure de la Depense.</param>
        /// <param name="unMontant">Montant de la Depense.</param>
        /// <param name="unCommerce">Montant admissible de la Depense.</param>
        /// <param name="uneCategorie">Montant admissible de la Depense.</param>
        public DepenseDTO(string dateTemps = "", double unMontant = 0, double unMontantAdmissible = 0, CommerceDTO unCommerce = null, CategorieDepenseDTO uneCategorie = null)
        {
            DateTemps = dateTemps;
            Montant = unMontant;
            MontantAdmissible = Montant * (0.01 * uneCategorie.Pourcentage);
            Commerce = unCommerce;
            Categorie = uneCategorie;
        }

        /// <summary>
        /// Constructeur avec le modèle Depense en paramètre.
        /// </summary>
        /// <param name="laDepense">L'objet du modèle Depense.</param>
        public DepenseDTO(DepenseModel laDepense)
        {
            DateTemps = laDepense.DateTemps;
            Montant = laDepense.Montant;
            MontantAdmissible = laDepense.CalculerDepenseAdmissible();
            Commerce = new CommerceDTO(laDepense.Commerce);
            Categorie = new CategorieDepenseDTO(laDepense.Categorie);
        }

        #endregion Constructeurs
    }
}
