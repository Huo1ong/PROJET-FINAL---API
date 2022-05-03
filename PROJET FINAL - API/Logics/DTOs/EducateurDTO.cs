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
        /// Propriété représentant le nom de l'Educateur.
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// Propriété représentant le nom de l'Educateur.
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
        /// <param name="nom">Nom de l'Educateur.</param>
        /// <param name="prenom">Prenom de l'Educateur.</param>
        /// <param name="date">Date de naissance de l'Educateur.</param>
        /// <param name="adresse">Adresse de l'Educateur.</param>
        /// <param name="ville">Ville de l'Educateur.</param>
        /// <param name="province">Province de l'Educateur.</param>
        /// <param name="telephone">Téléphone de l'Educateur.</param>
        public EducateurDTO(string nom = "", string prenom = "", string date = "", string adresse = "", string ville = "", string province = "", string telephone = "")
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = date;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            Telephone = telephone;
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
