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
                                                "   FROM T_Commerces " +
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
                                                " FROM T_Commerces " +
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
                                                " FROM T_Commerces " +
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
                                                "   FROM T_Commerces ", connexion);

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

        /// <summary>
        /// Méthode de service permettant d'ajouter un Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du Commerce.</param>
        public void AjouterCommerce(CommerceDTO commerceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Commerces (Description, Adresse, Telephone) " +
                                  " VALUES (@description, @adresse, @telephone) ";

            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 100);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            descriptionParam.Value = commerceDTO.Description;
            adresseParam.Value = commerceDTO.Adresse;
            telephoneParam.Value = commerceDTO.Telephone;

            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(telephoneParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un commerce", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du Commerce.</param>
        public void ModifierCommerce(CommerceDTO commerceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Commerces " +
                                     " SET Adresse = @adresse, " +
                                     "     Telephone = @telephone " +
                                     " WHERE Description = @description ";

            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 100);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            descriptionParam.Value = commerceDTO.Description;
            adresseParam.Value = commerceDTO.Adresse;
            telephoneParam.Value = commerceDTO.Telephone;

            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(telephoneParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'un Commerce...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un Commerce.
        /// </summary>
        /// <param name="commerceDTO">Le DTO du Commerce.</param>
        public void SupprimerCommerce(CommerceDTO commerceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Commerces " +
                                   " WHERE idCommerce = @idCommerce ";

            SqlParameter idCommerceParam = new SqlParameter("@idCommerce", SqlDbType.Int);

            idCommerceParam.Value = ObtenirIdCommerce(commerceDTO.Description);

            command.Parameters.Add(idCommerceParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                {
                    throw new DBRelationException("Impossible de supprimer le Commerce.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un Commerce...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Commerces.
        /// </summary>
        public void ViderListeCommerce()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_Commerces";
            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                {
                    throw new DBRelationException("Impossible de supprimer le Commerce.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un Commerce...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
