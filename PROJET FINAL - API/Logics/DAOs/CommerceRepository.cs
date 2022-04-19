using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.Exceptions;

namespace PROJET_FINAL___API.Logics.DAOs
{
    public class CommerceRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static CommerceRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CommerceRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CommerceRepository();
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
        private CommerceRepository() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un Commerce selon ses informatiques uniques.
        /// </summary>
        /// <param name="description">Description du Commerce.</param>
        /// <returns>Le ID du Commerce.</returns>
        public int ObtenirIdCommerce(string description)
        {
            SqlCommand command = new SqlCommand(" SELECT idCommerce " +
                                                "   FROM T_Commerce " +
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
                throw new Exception("Erreur lors de l'obtention d'un id d'un commerce par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un Commerce selon ses informations uniques.
        /// </summary>
        /// <param name="description">Description du Commerce.</param>
        /// <returns>Le DTO de la Commerce.</returns>
        public CommerceDTO ObtenirCommerce(string description)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Commerce " +
                                                " WHERE Description = @description ", connexion);

            SqlParameter descParam = new SqlParameter("@description", SqlDbType.VarChar, 50);

            descParam.Value = description;

            command.Parameters.Add(descParam);

            CommerceDTO unCommerce;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unCommerce = new CommerceDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3)); 
                reader.Close();
                return unCommerce;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un Commerce par sa description...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un Commerce selon ses informations uniques.
        /// </summary>
        /// <param name="id">L'id du Commerce.</param>
        /// <returns>Le DTO de la Commerce.</returns>
        public CommerceDTO ObtenirCommerceAvecId(int id)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Commerce " +
                                                " WHERE IdCommerce = @id ", connexion);

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = id;

            command.Parameters.Add(idParam);

            CommerceDTO unCommerce;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unCommerce = new CommerceDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                reader.Close();
                return unCommerce;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un Commerce par son id...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Commerces.
        /// </summary>
        public List<CommerceDTO> ObtenirListeCommerce()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Commerce ", connexion);

            List<CommerceDTO> liste = new List<CommerceDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CommerceDTO commerce = new CommerceDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(commerce);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des commerces...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
