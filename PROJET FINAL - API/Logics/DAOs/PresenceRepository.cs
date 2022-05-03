using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.Exceptions;
using PROJET_FINAL___API.Logics.Models;
using PROJET_FINAL___API.Logics.DAOs;


/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace PROJET_FINAL___API.Logics.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'une présence.
    /// </summary>
    public class PresenceRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static PresenceRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static PresenceRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new PresenceRepository();
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
        private PresenceRepository() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir une Presence selon ses informations uniques.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="dateTemps">Date est Heure de la Présence.</param>
        /// <returns>Le DTO de la Présence.</returns>
        public PresenceDTO ObtenirPresence(string nomGarderie, string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Presences TP" +
                                                " INNER JOIN T_Enfants TEn ON TEn.idEnfant = TP.idEnfant" +
                                                " WHERE date = @date " +
                                                " AND idGarderie = @idGarderie", connexion);

            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            dateParam.Value = dateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);

            command.Parameters.Add(dateParam);
            command.Parameters.Add(idGarderieParam);

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                EnfantDTO enfant = new EnfantDTO(reader.GetString(4), reader.GetString(5), Convert.ToString(reader.GetDateTime(6)), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10));

                PresenceDTO unePresence = new PresenceDTO(Convert.ToString(reader.GetDateTime(0)), enfant);

                reader.Close();
                return unePresence;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une Presence par sa date/heure...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Présences.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        public List<PresenceDTO> ObtenirListePresence(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Presences TP " +
                                                " INNER JOIN T_Enfants TEn ON TEn.idEnfant = TP.idEnfant" +
                                                " WHERE idGarderie = @idGarderie ", connexion);


            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);

            command.Parameters.Add(idGarderieParam);

            List<PresenceDTO> liste = new List<PresenceDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EnfantDTO enfant = new EnfantDTO(reader.GetString(4), reader.GetString(5), Convert.ToString(reader.GetDateTime(6)), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10));

                    PresenceDTO unePresence = new PresenceDTO(Convert.ToString(reader.GetDateTime(0)), enfant);
                    liste.Add(unePresence);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des presences...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une Présences.
        /// </summary>
        /// <param name="presenceDTO">Le DTO de la Présence.</param>
        public void AjouterPresence(string nomGarderie, PresenceDTO presenceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Presences (Date, idGarderie, idEnfant) " +
                                  " VALUES (@date, @idGarderie, @idEnfant) ";

            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idEnfantParam = new SqlParameter("@idEnfant", SqlDbType.Int);

            dateParam.Value = presenceDTO.DateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);
            idEnfantParam.Value = EnfantRepository.Instance.ObtenirIdEnfant(presenceDTO.Enfant.Nom);

            command.Parameters.Add(dateParam);
            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idEnfantParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'une presences...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier une présence.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <param name="presenceDTO">Le DTO de la présence.</param>
        public void ModifierPresence(string nomGarderie, PresenceDTO presenceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Presences " +
                                     " SET date = @date," +
                                   " WHERE idEnfant = @idEnfant " +
                                   "   AND idGarderie = @idGarderie";
            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idEnfantParam = new SqlParameter("@idEnfant", SqlDbType.Int);

            dateParam.Value = presenceDTO.DateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);
            idEnfantParam.Value = EnfantRepository.Instance.ObtenirIdEnfant(presenceDTO.Enfant.Nom);

            command.Parameters.Add(dateParam);
            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idEnfantParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'une présence...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une présence.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        /// <param name="presenceDTO">Le DTO de la présence.</param>
        public void SupprimerPresence(string nomGarderie, PresenceDTO presenceDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Presences " +
                                   " WHERE idGarderie = @idGarderie " +
                                   " AND idEnfant = @idEnfant";

            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idEnfantParam = new SqlParameter("@idEnfant", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);
            idEnfantParam.Value = EnfantRepository.Instance.ObtenirIdEnfant(presenceDTO.Enfant.Nom);

            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idEnfantParam);

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
                        throw new DBRelationException("Erreur - Impossible de supprimer la présence.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une Présence...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des présence d'une Garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        public void ViderListePresence(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Presences " +
                                   " WHERE IdGarderie = @idGarderie ";

            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);

            command.Parameters.Add(idGarderieParam);

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
                    throw new DBRelationException("Erreur - Impossible de supprimer la présence.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la vidange des présences...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
