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
    /// Classe représentant le répository d'un educateur.
    /// </summary>
    public class EducateurRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static EducateurRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EducateurRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EducateurRepository();
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
        /// <param name="nom">Le nom de l'educateur.</param>
        /// <returns>Le ID de l'educateur.</returns>
        public int ObtenirIdEducateur(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT idEducateur " +
                                                "   FROM T_Educateurs " +
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
                throw new Exception("Erreur lors de l'obtention d'un id d'un educateur par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un educateur selon ses informations uniques.
        /// </summary>
        /// <param name="nom">Nom de l'educateur.</param>
        /// <returns>Le DTO de l'educateur.</returns>
        public EducateurDTO ObtenirEducateur(string nom)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Educateurs " +
                                                " WHERE nom = @nom ", connexion);

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);

            nomParam.Value = nom;

            command.Parameters.Add(nomParam);

            EducateurDTO uneducateur;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneducateur = new EducateurDTO(reader.GetString(1), reader.GetString(2), Convert.ToString(reader.GetDateTime(3)), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                reader.Close();
                return uneducateur;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un educateur par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des educateurs.
        /// </summary>
        /// <param name="nom">Le nom de l'educateur.</param>
        public List<EducateurDTO> ObtenirListeEducateur()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Educateurs ", connexion);

            List<EducateurDTO> liste = new List<EducateurDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EducateurDTO educateur = new EducateurDTO(reader.GetString(1), reader.GetString(2), Convert.ToString(reader.GetDateTime(3)), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    liste.Add(educateur);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des educateurs...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un educateur.
        /// </summary>
        /// <param name="educateurDTO">Le DTO de l'educateur.</param>
        public void AjouterEducateur(EducateurDTO educateurDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Educateurs (Nom, Prenom, DateNaissance, Adresse, Ville, Province, Telephone) " +
                                  " VALUES (@nom, @prenom, @date, @adresse, @ville, @province, @telephone) ";

            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 100);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 100);
            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 200);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);

            nomParam.Value = educateurDTO.Nom;
            prenomParam.Value = educateurDTO.Prenom;
            dateParam.Value = educateurDTO.DateDeNaissance;
            adresseParam.Value = educateurDTO.Adresse;
            villeParam.Value = educateurDTO.Ville;
            provinceParam.Value = educateurDTO.Province;
            telephoneParam.Value = educateurDTO.Telephone;

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
                throw new DBUniqueException("Erreur lors de l'ajout d'un educateur...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un educateur.
        /// </summary>
        /// <param name="educateurDTO">Le DTO de l'educateur.</param>
        public void ModifierEducateur(EducateurDTO educateurDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Educateurs " +
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

            nomParam.Value = educateurDTO.Nom;
            adresseParam.Value = educateurDTO.Adresse;
            villeParam.Value = educateurDTO.Ville;
            provinceParam.Value = educateurDTO.Province;
            telephoneParam.Value = educateurDTO.Telephone;

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
                throw new Exception("Erreur lors de la modification d'un educateur...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un educateur.
        /// </summary>
        /// <param name="educateurDTO">Le DTO de l'educateur.</param>
        public void SupprimerEducateur(EducateurDTO educateurDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Educateurs " +
                                   " WHERE idEducateur = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdEducateur(educateurDTO.Nom);

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
                    throw new DBRelationException("Impossible de supprimer l'educateur.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un educateur...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des educateurs.
        /// </summary>
        public void ViderListeEducateur()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_Educateurs";
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
                    throw new DBRelationException("Impossible de vider la liste d'educateurs.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de vider la liste des educateurs...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
