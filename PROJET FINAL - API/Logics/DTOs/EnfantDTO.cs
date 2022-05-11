using PROJET_FINAL___API.Logics.Models;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class EnfantDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant le nom de l'Enfant.
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// Propriété représentant le prenom de l'Enfant.
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Propriété représentant la date de Naissance de l'Enfant.
        /// </summary>
        public string DateDeNaissance { get; set; }
        /// <summary>
        /// Propriété représentant l'adresse de l'Enfant.
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Propriété représentant la ville de l'Enfant.
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// Propriété représentant la province de l'Enfant.
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// Propriété représenant le téléphone de l'Enfant.
        /// </summary>
        public string Telephone { get; set; }

        #endregion Proprietes

        #region Constructeurs
        public EnfantDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unNom">Nom de l'Enfant.</param>
        /// <param name="unPrenom">Prenom de l'Enfant.</param>
        /// <param name="uneDate">Date de naissance de l'Enfant.</param>
        /// <param name="uneAdresse">Adresse de l'Enfant.</param>
        /// <param name="uneVille">Ville de l'Enfant.</param>
        /// <param name="uneProvince">Province de l'Enfant.</param>
        /// <param name="unTelephone">Téléphone de l'Enfant.</param>
        public EnfantDTO(string unNom = "", string unPrenom = "", string uneDate = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unTelephone = "")
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
        /// Constructeur avec le modèle Enfant en paramètre.
        /// </summary>
        /// <param name="lEnfant">L'objet du modèle Enfant.</param>
        public EnfantDTO(EnfantModel lEnfant)
        {
            Nom = lEnfant.Nom;
            Prenom = lEnfant.Prenom;
            DateDeNaissance= lEnfant.DateDeNaissance;
            Adresse = lEnfant.Adresse;
            Ville = lEnfant.Ville;
            Province = lEnfant.Province;
            Telephone = lEnfant.Telephone;
        }

        #endregion Constructeurs
    }
}
