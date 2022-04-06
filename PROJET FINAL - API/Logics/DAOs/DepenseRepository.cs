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
        /// <param name="dateTemps">Date et Heure de la Depense.</param>
        /// <returns>Le ID de la Garderie.</returns>
        public int ObtenirIdDepense(string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT idDepense " +
                                                "   FROM T_Depenses " +
                                                "  WHERE DateTemps = @date ", connexion);

            SqlParameter nomParam = new SqlParameter("@date", SqlDbType.VarChar, 50);

            nomParam.Value = dateTemps;

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
                throw new Exception("Erreur lors de l'obtention d'un id d'une depense par son nom...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir une Depense selon ses informations uniques.
        /// </summary>
        /// <param name="dateTemps">Date est Heure de la Depense.</param>
        /// <returns>Le DTO de la Depense.</returns>
        public DepenseDTO ObtenirDepense(string dateTemps)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM T_Depenses " +
                                                " WHERE DateTemps = @date ", connexion);

            SqlParameter nomParam = new SqlParameter("@date", SqlDbType.VarChar, 50);

            nomParam.Value = dateTemps;

            command.Parameters.Add(nomParam);

            DepenseDTO uneDepense;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                uneDepense = new DepenseDTO(reader.GetString(1), Convert.ToDouble(reader.GetString(2)), Convert.ToDouble(reader.GetString(3))); 
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
        public List<DepenseDTO> ObtenirListeDepense()
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM T_Depenses ", connexion);

            List<DepenseDTO> liste = new List<DepenseDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DepenseDTO depense = new DepenseDTO(reader.GetString(1), Convert.ToDouble(reader.GetString(2)), Convert.ToDouble(reader.GetString(3));
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

            SqlParameter dateParam = new SqlParameter("@date", SqlDbType.VarChar, 100);
            SqlParameter montantParam = new SqlParameter("@montant", SqlDbType.Money);
            SqlParameter idGarderieParam = new SqlParameter("@idGarderie", SqlDbType.Int);
            SqlParameter idCategorieParam = new SqlParameter("@idCategorie", SqlDbType.Int);
            SqlParameter idCommerceParam = new SqlParameter("@idCommerce", SqlDbType.Int);

            dateParam.Value = depenseDTO.DateTemps;
            montantParam.Value = depenseDTO.Montant;
            idGarderieParam.Value = GarderieDAO.Instance.ObtenirIdGarderie(nomGarderie);
            idCategorieParam.Value = depenseDTO.Categorie.ID;
            idCommerceParam.Value = depenseDTO.Commerce.ID;

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

        #endregion
    }
}
