using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Logics.Models
{
    public class PresenceModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant  la date et l'heure de la présence.
        /// </summary>
        private string dateTemps;
        /// <summary>
        /// Propriété représentant  la date et l'heure de la présence.
        /// </summary>
        public string DateTemps
        {
            get { return dateTemps; }
            set
            {
                if (value.Length <= 50)
                    dateTemps = value;
                else
                    throw new Exception("La date et l'heure de la présence doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        ///  Attribut représentant l'enfant de la présence.
        /// </summary>
        private EnfantModel enfant;
        /// <summary>
        ///  Propriété représentant l'enfant de la présence.
        /// </summary>
        public EnfantModel Enfant
        {
            get { return enfant; }
            set
            {
                enfant = value;
            }
        }

        /// <summary>
        ///  Attribut représentant l'educateur de la présence.
        /// </summary>
        private EducateurModel educateur;
        /// <summary>
        ///  Propriété représentant l'educateur de la présence.
        /// </summary>
        public EducateurModel Educateur
        {
            get { return educateur; }
            set
            {
                educateur = value;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré : PRESENCE
        /// </summary>
        /// <param name="uneDateTemps">La date et l'heure de la présence</param>
        /// <param name="unEnfant">L'enfant de la présence</param>
        /// <param name="unEducateur">L'educateur de la présence</param>
        public PresenceModel(string uneDateTemps = "", EnfantModel unEnfant = null, EducateurModel unEducateur = null)
        {
            DateTemps = uneDateTemps;
            Enfant = unEnfant;
            Educateur = unEducateur;
        }

        #endregion Constructeurs

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Présence.
        /// </summary>
        /// <returns>Version textuelle de l'objet Présence.</returns>
        public override string ToString()
        {
            return DateTemps + "\n" + Enfant.ToString() + "\n" + Educateur.ToString();
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Présence.
        /// Deux objets Présence sont égaux s'ils ont la même date et heure.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is PresenceModel) && DateTemps.Equals((obj as PresenceModel).DateTemps);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Présence.
        /// </summary>
        /// <returns>HashCode de l'objet Présence.</returns>
        public override int GetHashCode()
        {
            return DateTemps.Length;
        }

        /// <summary>
        /// Méthode permettant d'obtenir le nom de l'enfant de la présence.
        /// </summary>
        /// <returns>le nom de l'enfant de la présence</returns>
        public string ObtenirEnfantNom()
        {
            return Enfant.Nom;
        }

        /// <summary>
        /// Méthode permettant d'obtenir le nom de l'educateur de la présence.
        /// </summary>
        /// <returns>le nom de l'educateur de la présence</returns>
        public string ObtenirEducateurNom()
        {
            return Educateur.Nom;
        }

        #endregion
    }
}
