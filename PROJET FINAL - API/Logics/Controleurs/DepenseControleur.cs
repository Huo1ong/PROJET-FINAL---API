using System;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.DAOs;

namespace PROJET_FINAL___API.Logics.Controleurs
{
    public class DepenseControleur {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe DepenseControleur.
        /// </summary>
        private static DepenseControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static DepenseControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new DepenseControleur();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Controleurs

        /// <summary>
        /// Constructeur par défaut de la classe.
        /// </summary>
        private DepenseControleur() { }

        #endregion Controleurs


    }
}
