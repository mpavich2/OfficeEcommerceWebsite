using System.Collections.Generic;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the IRepository interface class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        #region Properties

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <value>
        ///     The count.
        /// </value>
        int Count { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Lists the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        IEnumerable<T> List(QueryOptions<T> options);

        /// <summary>
        ///     Gets the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        T Get(QueryOptions<T> options);

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        ///     Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get(string id);

        /// <summary>
        ///     Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        void Save();

        #endregion
    }
}