using PROJET_FINAL___API.Logics.Models;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class EducateurDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom de l'Educateur.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Propriété représentant le prenom de l'Educateur.
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Propriété représentant la date de naissance de l'Educateur.
        /// </summary>
        public string DateDeNaissance { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse de l'Educateur.
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant la ville de l'Educateur.
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Propriété représentant la province de l'Educateur.
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Propriété représenant le téléphone de l'Educateur.
        /// </summary>
        public string Telephone { get; set; }

        #endregion Proprietes

        #region Constructeurs
        public EducateurDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unNom">Nom de l'Educateur.</param>
        /// <param name="unPrenom">Prenom de l'Educateur.</param>
        /// <param name="uneDate">Date de naissance de l'Educateur.</param>
        /// <param name="uneAdresse">Adresse de l'Educateur.</param>
        /// <param name="uneVille">Ville de l'Educateur.</param>
        /// <param name="uneProvince">Province de l'Educateur.</param>
        /// <param name="unTelephone">Téléphone de l'Educateur.</param>
        public EducateurDTO(string unNom = "", string unPrenom = "", string uneDate = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
        {
            Nom = unNom;
            Prenom = unPrenom;
            DateDeNaissance = uneDate;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            Telephone = unTelephone;
        }

        /// <summary>
        /// Constructeur avec le modèle Educateur en paramètre.
        /// </summary>
        /// <param name="lEducateur">L'objet du modèle Educateur.</param>
        public EducateurDTO(EducateurModel lEducateur)
        {
            Nom = lEducateur.Nom;
            Prenom = lEducateur.Prenom;
            DateDeNaissance = lEducateur.DateDeNaissance;
            Adresse = lEducateur.Adresse;
            Ville = lEducateur.Ville;
            Province = lEducateur.Province;
            Telephone = lEducateur.Telephone;
        }

        #endregion Constructeurs
    }
}
