using System.Collections.Generic;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the OfficeProductListViewModel class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class OfficeProductListViewModel
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the products.
        /// </summary>
        /// <value>
        ///     The products.
        /// </value>
        public IEnumerable<OfficeProduct> Products { get; set; }

        /// <summary>
        ///     Gets or sets the current route.
        /// </summary>
        /// <value>
        ///     The current route.
        /// </value>
        public RouteDictionary CurrentRoute { get; set; }

        /// <summary>
        ///     Gets or sets the total pages.
        /// </summary>
        /// <value>
        ///     The total pages.
        /// </value>
        public int TotalPages { get; set; }

        /// <summary>
        ///     Gets or sets the product types.
        /// </summary>
        /// <value>
        ///     The product types.
        /// </value>
        public IEnumerable<ProductType> ProductTypes { get; set; }

        /// <summary>
        ///     Gets or sets the images.
        /// </summary>
        /// <value>
        ///     The images.
        /// </value>
        public IEnumerable<Image> Images { get; set; }

        #endregion
    }
}