using System.Linq;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the QueryExtensions class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class QueryExtensions
    {
        #region Methods

        /// <summary>
        ///     Pages the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="pageNumber">The pagenumber.</param>
        /// <param name="pageSize">The pagesize.</param>
        /// <returns></returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> items,
            int pageNumber, int pageSize)
        {
            return items
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize);
        }

        #endregion
    }
}