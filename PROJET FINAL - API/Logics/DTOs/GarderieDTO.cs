using PROJET_FINAL___API.Logics.Models;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class GarderieDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom de la Garderie.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse de la Garderie.
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant la ville de la Garderie.
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Propriété représentant la province de la Garderie.
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Propriété représenant le téléphone de la Garderie.
        /// </summary>
        public string Telephone { get; set; }

        #endregion Proprietes

        #region Constructeurs

        public GarderieDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unNom">Nom de la Garderie.</param>
        /// <param name="uneAdresse">Adresse de la Garderie.</param>
        /// <param name="uneVille">Ville de la Garderie.</param>
        /// <param name="uneProvince">Province de la Garderie.</param>
        /// <param name="unTelephone">Téléphone de la Garderie.</param>
        public GarderieDTO(string unNom = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
        {
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
        }

        /// <summary>
        /// Constructeur avec le modèle Garderie en paramètre.
        /// </summary>
        /// <param name="laGarderie">L'objet du modèle Garderie.</param>
        public GarderieDTO(GarderieModel laGarderie)
        {
            Nom = laGarderie.Nom;
            Adresse = laGarderie.Adresse;
            Ville = laGarderie.Ville;
            Province = laGarderie.Province;
            Telephone = laGarderie.Telephone;
        }

        #endregion Constructeurs
    }
}