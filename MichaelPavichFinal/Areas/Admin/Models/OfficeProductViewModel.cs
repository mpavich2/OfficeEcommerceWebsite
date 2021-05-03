using System.Collections.Generic;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the OfficeProductViewModel class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class OfficeProductViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the product.
        /// </summary>
        /// <value>
        ///     The product.
        /// </value>
        public OfficeProduct Product { get; set; }

        /// <summary>
        ///     Gets or sets the types.
        /// </summary>
        /// <value>
        ///     The types.
        /// </value>
        public IEnumerable<ProductType> Types { get; set; }

        #endregion
    }
}