using System.Collections.Generic;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the CartViewModel class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class CartViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the list.
        /// </summary>
        /// <value>
        ///     The list.
        /// </value>
        public IEnumerable<CartItem> List { get; set; }

        /// <summary>
        ///     Gets or sets the subtotal.
        /// </summary>
        /// <value>
        ///     The subtotal.
        /// </value>
        public double Subtotal { get; set; }

        /// <summary>
        ///     Gets or sets the book grid route.
        /// </summary>
        /// <value>
        ///     The book grid route.
        /// </value>
        public RouteDictionary BookGridRoute { get; set; }

        #endregion
    }
}