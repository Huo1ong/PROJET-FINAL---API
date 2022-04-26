using PROJET_FINAL___API.Logics.Models;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class CategorieDepenseDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la description de la Catégorie.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Propriété représentant le pourcentage de la Catégorie.
        /// </summary>
        public double Pourcentage { get; set; }

        #endregion Proprietes

        #region Constructeurs

        public CategorieDepenseDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="uneDescription">Description de la Catégorie.</param>
        /// <param name="unPourcentage">Le pourcentage de la Catégorie.</param>
        public CategorieDepenseDTO(string uneDescription = "", double unPourcentage = 0)
        {
            Description = uneDescription;
            Pourcentage = unPourcentage;
        }

        /// <summary>
        /// Constructeur avec le modèle CategorieDepense en paramètre.
        /// </summary>
        /// <param name="laCategorie">L'objet du modèle CategorieDepense.</param>
        public CategorieDepenseDTO(CategorieDepenseModel laCategorie)
        {
            if (laCategorie != null)
            {
                Description = laCategorie.Description;
                Pourcentage = laCategorie.Pourcentage;
            }
            else
            {
                Description = null;
                Pourcentage = 0;
            }

        }

        #endregion Constructeurs
    }
}
