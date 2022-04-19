using PROJET_FINAL___API.Logics.Models;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class CommerceDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la description du Commerce.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse du Commerce.
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant le telephone du Commerce.
        /// </summary>
        public string Telephone { get; set; }

        #endregion Proprietes

        #region Constructeurs

        public CommerceDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="uneDescription">Description du Commerce.</param>
        /// <param name="uneAdresse">L'Adresse du Commerce.</param>
        /// <param name="unTelephone">Telephone du Commerce.</param>
        public CommerceDTO(string uneDescription = "", string uneAdresse = "", string unTelephone = "")
        {
            Description = uneDescription;
            Adresse = uneAdresse;
            Telephone = unTelephone;
        }

        /// <summary>
        /// Constructeur avec le modèle Commerce en paramètre.
        /// </summary>
        /// <param name="leCommerce">L'objet du modèle Commerce.</param>
        public CommerceDTO(CommerceModel leCommerce)
        {
            Description = leCommerce.Description;
            Adresse= leCommerce.Adresse;
            Telephone = leCommerce.Telephone;

        }

        #endregion Constructeurs
    }
}
