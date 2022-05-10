using PROJET_FINAL___API.Logics.Models;
using System;

namespace PROJET_FINAL___API.Logics.DTOs
{
    public class PresenceDTO
    {
        #region Proprietes
        /// <summary>
        /// Propriété représentant la date et l'heure de la Presence.
        /// </summary>
        public string DateTemps { get; set; }
        /// <summary>
        /// Propriété représentant l'enfant de la Presence.
        /// </summary>
        public EnfantDTO Enfant { get; set; }
        /// <summary>
        /// Propriété représentant l'educateur de la Presence.
        /// </summary>
        public EducateurDTO Educateur { get; set; }

        #endregion Proprietes

        #region Constructeurs

        public PresenceDTO() { }

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="dateTemps">Date et Heure de la Présence.</param>
        /// <param name="unEnfant">Enfant de la Présence.</param>
        /// <param name="unEducateur">Educateur de la Présence.</param>
        public PresenceDTO(string dateTemps = "", EnfantDTO unEnfant = null, EducateurDTO unEducateur = null)
        {
            DateTemps = dateTemps;
            Enfant = unEnfant;
            Educateur = unEducateur;
        }

        /// <summary>
        /// Constructeur avec le modèle Présence en paramètre.
        /// </summary>
        /// <param name="laPresence">L'objet du modèle Presence.</param>
        public PresenceDTO(PresenceModel laPresence)
        {
            DateTemps = laPresence.DateTemps;
            Enfant = new EnfantDTO(laPresence.Enfant);
            Educateur = new EducateurDTO(laPresence.Educateur);
        }

        #endregion Constructeurs
    }
}
