using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.Exceptions;

namespace PROJET_FINAL___API.Logics.DAOs
{
    public class CategorieDepenseRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static CategorieDepenseRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CategorieDepenseRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CategorieDepenseRepository();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur privée du repository.
        /// </summary>
        private CategorieDepenseRepository() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'une Categorie selon ses informatiques uniques.
        /// </summary>
        /// <param name="description">Description de la Categorie.</param>
        /// <returns>Le ID du Commerce.</returns>
        public int ObtenirIdCategorieDepense(string description)
        {
            SqlCommand command = new SqlCommand(" SELECT idCategorieDepense " +
                                                "   FROM T_CategoriesDepense " +
                                                "  WHERE Description = @description ", connexion);

            SqlParameter descParam = new SqlParameter("@description", SqlDbType.VarChar, 50);

            descParam.Value = description;

            command.Parameters.Add(descParam);

            int id;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
                reader.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un id d'une Categorie par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une Categorie selon ses informations uniques.
        /// </summary>
        /// <param name="description">Description de la Categorie.</param>
        /// <returns>Le DTO de la Categorie.</returns>
        public CategorieDepenseDTO ObtenirCategorie(string description)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_CategoriesDepense " +
                                                " WHERE Description = @description ", connexion);

            SqlParameter descParam = new SqlParameter("@description", SqlDbType.VarChar, 50);

            descParam.Value = description;

            command.Parameters.Add(descParam);

            CategorieDepenseDTO uneCategorie;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneCategorie = new CategorieDepenseDTO(reader.GetString(1), Convert.ToDouble(reader.GetString(2)));
                reader.Close();
                return uneCategorie;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une Categorie par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Categories.
        /// </summary>
        public List<CategorieDepenseDTO> ObtenirListeCategories()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Categories ", connexion);

            List<CategorieDepenseDTO> liste = new List<CategorieDepenseDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CategorieDepenseDTO categorie = new CategorieDepenseDTO(reader.GetString(1), Convert.ToDouble(reader.GetString(2)));
                    liste.Add(categorie);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des categories...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
