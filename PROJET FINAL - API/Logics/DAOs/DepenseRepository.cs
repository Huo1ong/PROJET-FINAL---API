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
    /// Classe représentant le répository d'une depense.
    /// </summary>
    public class DepenseRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static DepenseRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static DepenseRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new DepenseRepository();
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
        private DepenseRepository() : base() { }

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'une Depense selon ses informatiques uniques.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="dateTemps">Date et Heure de la Depense.</param>
        /// <returns>Le ID de la Garderie.</returns>
        public int ObtenirIdDepense(string nomGarderie, string dateTemps)
        {
             SqlCommand command = new SqlCommand(" SELECT idDepense " +
                                                " FROM T_Depenses TD " +
                                                " WHERE DateTemps = @date " +
                                                " AND IdGarderie = @idGarderie", connexion);

            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            dateParam.Value = dateTemps;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);

            command.Parameters.Add(dateParam);
            command.Parameters.Add(idGarderieParam);

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
                throw new Exception("Erreur lors de l'obtention d'un id d'une dépense par sa date...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une Depense selon ses informations uniques.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        /// <param name="dateTemps">Date est Heure de la Depense.</param>
        /// <returns>Le DTO de la Depense.</returns>
        public DepenseDTO ObtenirDepense(string nomGarderie, string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM ((T_Depenses TD" +
                                                " INNER JOIN T_Commerces TCo ON TCo.idCommerce = TD.idCommerce)" +
                                                " INNER JOIN T_CategoriesDepense TCa ON TCa.idCategorieDepense = TD.idCategorieDepense)" +
                                                " WHERE DateTemps = @date " +
                                                " AND IdGarderie = @idGarderie", connexion);

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

                //CategorieDepenseDTO categorie = CategorieDepenseRepository.Instance.ObtenirCategorieDepenseAvecId(reader.GetInt32(4));
                CategorieDepenseDTO categorie = new CategorieDepenseDTO(reader.GetString(11), reader.GetDouble(12));

                //CommerceDTO commerce = CommerceRepository.Instance.ObtenirCommerceAvecId(reader.GetInt32(5));
                CommerceDTO commerce = new CommerceDTO(reader.GetString(7), reader.GetString(8), reader.GetString(9));

                DepenseDTO uneDepense = new DepenseDTO(Convert.ToString(reader.GetDateTime(1)), Convert.ToDouble(reader.GetDecimal(2)), Convert.ToDouble(reader.GetDecimal(2)) * categorie.Pourcentage, commerce, categorie);

                reader.Close();
                return uneDepense;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une Depense par sa date/heure...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Dépenses.
        /// </summary>
        /// <param name="nomGarderie">Nom de la Garderie</param>
        public List<DepenseDTO> ObtenirListeDepense(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM ((T_Depenses TD " +
                                                "INNER JOIN T_Commerces TCo ON TCo.idCommerce = TD.idCommerce) " +
                                                "INNER JOIN T_CategoriesDepense TCa ON TCa.idCategorieDepense = TD.idCategorieDepense)" +
                                                " WHERE IdGarderie = @idGarderie ", connexion);


            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);

            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);

            command.Parameters.Add(idGarderieParam);

            List<DepenseDTO> liste = new List<DepenseDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //CategorieDepenseDTO categorie = CategorieDepenseRepository.Instance.ObtenirCategorieDepenseAvecId(reader.GetInt32(4));
                    CategorieDepenseDTO categorie = new CategorieDepenseDTO(reader.GetString(11),reader.GetDouble(12));

                    //CommerceDTO commerce = CommerceRepository.Instance.ObtenirCommerceAvecId(reader.GetInt32(5));
                    CommerceDTO commerce = new CommerceDTO(reader.GetString(7), reader.GetString(8), reader.GetString(9));

                    DepenseDTO depense = new DepenseDTO(Convert.ToString(reader.GetDateTime(1)), Convert.ToDouble(reader.GetDecimal(2)), Convert.ToDouble(reader.GetDecimal(2)) * categorie.Pourcentage, commerce, categorie);
                    liste.Add(depense);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des depenses...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter une Dépense.
        /// </summary>
        /// <param name="depenseDTO">Le DTO de la dépense.</param>
        public void AjouterDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_Depenses (DateTemps, Montant, idGarderie, idCategorieDepense, idCommerce) " +
                                  " VALUES (@date, @montant, @idGarderie, @idCategorie, @idCommerce) ";

            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.DateTime);
            SqlParameter montantParam = new SqlParameter("@montant", SqlDbType.Money);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idCategorieParam = new SqlParameter("@idCategorie", SqlDbType.Int);
            SqlParameter idCommerceParam = new SqlParameter("@idCommerce", SqlDbType.Int);

            dateParam.Value = depenseDTO.DateTemps;
            montantParam.Value = depenseDTO.Montant;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);
            idCategorieParam.Value = CategorieDepenseRepository.Instance.ObtenirIdCategorieDepense(depenseDTO.Categorie.Description);
            idCommerceParam.Value = CommerceRepository.Instance.ObtenirIdCommerce(depenseDTO.Commerce.Description);

            command.Parameters.Add(dateParam);
            command.Parameters.Add(montantParam);
            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idCategorieParam);
            command.Parameters.Add(idCommerceParam);

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
        /// Méthode de service permettant de modifier une dépense.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la garderie.</param>
        /// <param name="depenseDTO">Le DTO de la dépense.</param>
        public void ModifierDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_Depenses " +
                                     " SET Montant = @montant," +
                                     " idCommerce = @idCommerce," +
                                     " idCategorieDepense = @idCategorieDepense  " +
                                   " WHERE DateTemps = @dateTemps " +
                                   "   AND idGarderie = @idGarderie";
            SqlParameter dateParam = new SqlParameter("@dateTemps", SqlDbType.DateTime);
            SqlParameter montantParam = new SqlParameter("@montant", SqlDbType.Money);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idCommerceParam = new SqlParameter("@idCommerce", SqlDbType.Int);
            SqlParameter idCategorieDepenseParam = new SqlParameter("@idCategorieDepense", SqlDbType.Int);

            dateParam.Value = depenseDTO.DateTemps;
            montantParam.Value = depenseDTO.Montant;
            idGarderieParam.Value = GarderieRepository.Instance.ObtenirIdGarderie(nomGarderie);
            idCommerceParam.Value = CommerceRepository.Instance.ObtenirIdCommerce(depenseDTO.Commerce.Description);
            idCategorieDepenseParam.Value = CategorieDepenseRepository.Instance.ObtenirIdCategorieDepense(depenseDTO.Categorie.Description);

            command.Parameters.Add(dateParam);
            command.Parameters.Add(montantParam);
            command.Parameters.Add(idGarderieParam);
            command.Parameters.Add(idCommerceParam);
            command.Parameters.Add(idCategorieDepenseParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'une dépense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une dépense.
        /// </summary>
        /// <param name="nomGarderie">Le nom de la Garderie.</param>
        /// <param name="depenseDTO">Le DTO de la dépense.</param>
        public void SupprimerDepense(string nomGarderie, DepenseDTO depenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Depenses " +
                                   " WHERE idDepense = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdDepense(nomGarderie, depenseDTO.DateTemps);

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
                    if (e.Message.Contains("FK_Depenses_CategorieDepense_Commerce"))
                        throw new DBRelationException("Erreur - Impossible de supprimer la dépense. Catégorie de Dépense(s) associé(s).", e);
                    else
                        throw new DBRelationException("Erreur - Impossible de supprimer la dépense. Commerce(s) associé(s).", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une dépense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des dépense d'une Garderie.
        /// </summary>
        /// <param name="nomGarderie">Le nom du Garderie.</param>
        public void ViderListeDepense(string nomGarderie)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_Depenses " +
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
                    if (e.Message.Contains("FK_Depenses_CategorieDepense_Commerce"))
                        throw new DBRelationException("Erreur - Impossible de supprimer le département. Catégorie de Dépense(s) associé(s).", e);
                    else
                        throw new DBRelationException("Erreur - Impossible de supprimer le département. Commerce(s) associé(s).", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la vidange des dépenses...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
