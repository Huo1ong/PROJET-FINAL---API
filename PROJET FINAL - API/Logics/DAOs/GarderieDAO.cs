using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.Exceptions;

/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace PROJET_FINAL___API.Logics.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'un cégep.
    /// </summary>
    public class GarderieDAO : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static GarderieDAO instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static GarderieDAO Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new GarderieDAO();
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
        private GarderieDAO() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'une garderie selon ses informatiques uniques.
        /// </summary>
        /// <param name="nom">Le titre du Garderie.</param>
        /// <returns>Le ID de la Garderie.</returns>
        public int ObtenirIdGarderie(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT idGarderie " +
                                                "   FROM T_Garderies " +
                                                "  WHERE Nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);

            nomParam.Value = nom;

            command.Parameters.Add(nomParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'une garderie par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une Garderie selon ses informations uniques.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie.</param>
        /// <returns>Le DTO de la Garderie.</returns>
        public GarderieDTO ObtenirGarderie(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Garderies " +
                                                " WHERE nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);

            nomParam.Value = nom;

            command.Parameters.Add(nomParam);

            GarderieDTO uneGarderie;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneGarderie = new GarderieDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                reader.Close();
                return uneGarderie;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une Garderie par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Garderies.
        /// </summary>
        /// <param name="nom">Le nom de la Garderie.</param>
        public List<GarderieDTO> ObtenirListeGarderie()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Garderies ", connexion);

            List<GarderieDTO> liste = new List<GarderieDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GarderieDTO garderie = new GarderieDTO(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    liste.Add(garderie);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des garderies...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une Garderie.
        /// </summary>
        /// <param name="garderieDTO">Le DTO de la garderie.</param>
        public void AjouterGarderie(GarderieDTO garderieDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Garderies (Nom, Adresse, Ville, Province, Telephone) " +
                                  " VALUES (@nom, @adresse, @ville, @province, @telephone) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = garderieDTO.Nom;
            adresseParam.Value = garderieDTO.Adresse;
            villeParam.Value = garderieDTO.Ville;
            provinceParam.Value = garderieDTO.Province;
            telephoneParam.Value = garderieDTO.Telephone;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(telephoneParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier une Garderie.
        /// </summary>
        /// <param name="garderieDTO">Le DTO de la Garderie.</param>
        public void ModifierGarderie(GarderieDTO garderieDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Garderies " +
                                     " SET Adresse = @adresse, " +
                                     "     Ville = @ville, " +
                                     "     Province = @province, " +
                                     "     Telephone = @telephone " +
                                     " WHERE Nom = @nom ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = garderieDTO.Nom;
            adresseParam.Value = garderieDTO.Adresse;
            villeParam.Value = garderieDTO.Ville;
            provinceParam.Value = garderieDTO.Province;
            telephoneParam.Value = garderieDTO.Telephone;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(telephoneParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'une Garderie...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une Garderie.
        /// </summary>
        /// <param name="garderieDTO">Le DTO de la Garderie.</param>
        public void SupprimerGarderie(GarderieDTO garderieDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Garderies " +
                                   " WHERE idGarderie = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdGarderie(garderieDTO.Nom);

            command.Parameters.Add(idParam);

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
                    throw new DBRelationException("Impossible de supprimer la Garderie.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une Garderie...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des Garderies.
        /// </summary>
        public void ViderListeGarderie()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_Garderies";
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
                    throw new DBRelationException("Impossible de supprimer la Garderie.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une Garderie...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
