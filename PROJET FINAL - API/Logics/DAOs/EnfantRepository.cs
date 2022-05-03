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
    /// Classe représentant le répository d'un enfant.
    /// </summary>
    public class EnfantRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static EnfantRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EnfantRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EnfantRepository();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes


        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'une garderie selon ses informatiques uniques.
        /// </summary>
        /// <param name="nom">Le nom de l'Enfant.</param>
        /// <returns>Le ID de l'Enfant.</returns>
        public int ObtenirIdEnfant(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT idEnfant " +
                                                "   FROM T_Enfants " +
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
                throw new Exception("Erreur lors de l'obtention d'un id d'un enfant par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un Enfant selon ses informations uniques.
        /// </summary>
        /// <param name="nom">Nom de l'enfant.</param>
        /// <returns>Le DTO de l'Enfant.</returns>
        public EnfantDTO ObtenirEnfant(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Enfants " +
                                                " WHERE nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);

            nomParam.Value = nom;

            command.Parameters.Add(nomParam);

            EnfantDTO unEnfant;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unEnfant = new EnfantDTO(reader.GetString(1), reader.GetString(2), Convert.ToString(reader.GetDateTime(3)), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                reader.Close();
                return unEnfant;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un Enfant par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Enfants.
        /// </summary>
        /// <param name="nom">Le nom de l'enfant.</param>
        public List<EnfantDTO> ObtenirListeEnfant()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Enfants ", connexion);

            List<EnfantDTO> liste = new List<EnfantDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EnfantDTO enfant = new EnfantDTO(reader.GetString(1), reader.GetString(2), Convert.ToString(reader.GetDateTime(3)), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    liste.Add(enfant);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des enfants...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un Enfant.
        /// </summary>
        /// <param name="enfantDTO">Le DTO de l'enfant.</param>
        public void AjouterEnfant(EnfantDTO enfantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Enfants (Nom, Prenom, DateNaissance, Adresse, Ville, Province, Telephone) " +
                                  " VALUES (@nom, @prenom, @date, @adresse, @ville, @province, @telephone) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 100);
            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = enfantDTO.Nom;
            prenomParam.Value = enfantDTO.Prenom;
            dateParam.Value = enfantDTO.DateDeNaissance;
            adresseParam.Value = enfantDTO.Adresse;
            villeParam.Value = enfantDTO.Ville;
            provinceParam.Value = enfantDTO.Province;
            telephoneParam.Value = enfantDTO.Telephone;

            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(dateParam);
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
                throw new DBUniqueException("Erreur lors de l'ajout d'un enfant...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un Enfant.
        /// </summary>
        /// <param name="enfantDTO">Le DTO de l'Enfant.</param>
        public void ModifierEnfant(EnfantDTO enfantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Enfants " +
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

            nomParam.Value = enfantDTO.Nom;
            adresseParam.Value = enfantDTO.Adresse;
            villeParam.Value = enfantDTO.Ville;
            provinceParam.Value = enfantDTO.Province;
            telephoneParam.Value = enfantDTO.Telephone;

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
                throw new Exception("Erreur lors de la modification d'un Enfant...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un Enfant.
        /// </summary>
        /// <param name="EnfantDTO">Le DTO de l'Enfant.</param>
        public void SupprimerEnfant(EnfantDTO enfantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Enfants " +
                                   " WHERE idEnfant = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdEnfant(enfantDTO.Nom);

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
                    throw new DBRelationException("Impossible de supprimer l'enfant.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un Enfant...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des enfants.
        /// </summary>
        public void ViderListeEnfant()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_Enfants";
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
                    throw new DBRelationException("Impossible de vider la liste d'enfants.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de vider la liste des enfants...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
