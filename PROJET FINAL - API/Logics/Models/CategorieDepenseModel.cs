using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJET_FINAL___API.Logics.Models
{
    public class CategorieDepenseModel
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant la description de la categorie de depense.
        /// </summary>
        private string description;
        /// <summary>
        /// Propriété représentant la description de la categorie de depense.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= 50)
                    description = value;
                else
                    throw new Exception("La description de la categorie de depense doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le pourcentage de la categorie de depense.
        /// </summary>
        private double pourcentage;
        /// <summary>
        /// Propriété représentant le pourcentage de la categorie de depense.
        /// </summary>
        public double Pourcentage
        {
            get { return pourcentage; }
            set
            {
                if(value.ToString().Length <= 20)
                 pourcentage = value;

                else
                {
                    throw new Exception("Le pourcentage de la categorie de depense doit avoir un maximum de 50 caractères.");
                }
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré : CATEGORIEDEPENSE
        /// </summary>
        /// <param name="uneDescription">La description de la categorie de depense</param>
        /// <param name="unPourcentage">Le pourcentage de la categorie de depense</param>
        public CategorieDepenseModel(string uneDescription = "", double unPourcentage = 0)
        {
            Description = uneDescription;
            Pourcentage = unPourcentage;
        }

        #endregion Constructeurs

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet CategorieDepense.
        /// </summary>
        /// <returns>Version textuelle de l'objet CategorieDepense.</returns>
        public override string ToString()
        {
            return Description + "\n" + Pourcentage;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet CategorieDepense.
        /// Deux objets CategorieDepense sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is CategorieDepenseModel) && Description.Equals((obj as CategorieDepenseModel).Description);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet CategorieDepense.
        /// </summary>
        /// <returns>HashCode de l'objet CategorieDepense.</returns>
        public override int GetHashCode()
        {
            return Description.Length;
        }

        #endregion Overrides
    }
}
