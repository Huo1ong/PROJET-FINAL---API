using System;

/// <summary>
/// Namespace pour les classes d'exception.
/// </summary>
namespace PROJET_FINAL___API.Logics.Exceptions
{
    /// <summary>
    /// Classe pour l'exception DBUniqueException
    /// </summary>
    public class DBRelationException : Exception
    {
        /// <summary>
        /// Constructeur sans paramètres.
        /// </summary>
        public DBRelationException() { }

        /// <summary>
        /// Constructeur avec un message comme paramètre.
        /// </summary>
        /// <param name="message">Le message.</param>
        public DBRelationException(string message) : base(message) { }

        /// <summary>
        /// Constructeur avec le message et l'inner exception comme paramètres.
        /// </summary>
        /// <param name="message">Le message.</param>
        /// <param name="inner">L'inner exception.</param>
        public DBRelationException(string message, Exception inner) : base(message, inner) { }
    }
}
