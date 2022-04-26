﻿using System;
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
        public CategorieDepenseDTO ObtenirCategorieDepense(string description)
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
                uneCategorie = new CategorieDepenseDTO(reader.GetString(1), reader.GetDouble(2));
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
        /// Méthode de service permettant d'obtenir une Categorie selon ses informations uniques.
        /// </summary>
        /// <param name="description">Description de la Categorie.</param>
        /// <returns>Le DTO de la Categorie.</returns>
        public CategorieDepenseDTO ObtenirCategorieDepenseAvecId(int id)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_CategoriesDepense " +
                                                " WHERE IdCategorieDepense = @id ", connexion);

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.VarChar, 50);

            idParam.Value = id;

            command.Parameters.Add(idParam);

            CategorieDepenseDTO uneCategorie;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneCategorie = new CategorieDepenseDTO(reader.GetString(1), reader.GetDouble(2));
                reader.Close();
                return uneCategorie;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'une Categorie par son id...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des Categories.
        /// </summary>
        public List<CategorieDepenseDTO> ObtenirListeCategorieDepense()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_CategoriesDepense ", connexion);

            List<CategorieDepenseDTO> liste = new List<CategorieDepenseDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CategorieDepenseDTO categorie = new CategorieDepenseDTO(reader.GetString(1), reader.GetDouble(2));
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

        /// <summary>
        /// Méthode de service permettant d'ajouter un CategorieDepense.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO du CategorieDepense.</param>
        public void AjouterCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO T_CategoriesDepense (Description, Pourcentage) " +
                                  " VALUES (@description, @pourcentage) ";

            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 100);
            SqlParameter pourcentageParam = new SqlParameter("@pourcentage", SqlDbType.Int);

            descriptionParam.Value = categorieDepenseDTO.Description;
            pourcentageParam.Value = categorieDepenseDTO.Pourcentage;

            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(pourcentageParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'une categorie depense", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier une CategorieDepense.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO de la CategorieDepense.</param>
        public void ModifierCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE T_CategoriesDepense " +
                                     " SET Pourcentage = @pourcentage, " +
                                     " WHERE Description = @description ";

            SqlParameter descriptionParam = new SqlParameter("@description", SqlDbType.VarChar, 100);
            SqlParameter pourcentageParam = new SqlParameter("@pourcentage", SqlDbType.Int);

            descriptionParam.Value = categorieDepenseDTO.Description;
            pourcentageParam.Value = categorieDepenseDTO.Pourcentage;

            command.Parameters.Add(descriptionParam);
            command.Parameters.Add(pourcentageParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'une Categorie Depense...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer une CategorieDepense.
        /// </summary>
        /// <param name="categorieDepenseDTO">Le DTO dr la CategorieDepense.</param>
        public void SupprimerCategorieDepense(CategorieDepenseDTO categorieDepenseDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM T_CategoriesDepense " +
                                   " WHERE idCategorieDepense = @CategorieDepense ";

            SqlParameter idCategorieDepenseParam = new SqlParameter("@CategorieDepense", SqlDbType.Int);

            idCategorieDepenseParam.Value = ObtenirIdCategorieDepense(categorieDepenseDTO.Description);

            command.Parameters.Add(idCategorieDepenseParam);

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
                    throw new DBRelationException("Impossible de supprimer la CategorieDepense.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'une CategorieDepense...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des CategoriesDepense.
        /// </summary>
        public void ViderListeCategorieDepense()
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE FROM T_CategoriesDepense";
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
                    throw new DBRelationException("Impossible de vider la CategorieDepense.", e);
                }
                else throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de vider une CategorieDepense...", ex);
            }

            finally
            {
                FermerConnexion();
            }
        }
        #endregion
    }
}
