using System.Collections.Generic;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the ProductType class
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class ProductType
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the product type identifier.
        /// </summary>
        /// <value>
        ///     The product type identifier.
        /// </value>
        public string ProductTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the products.
        /// </summary>
        /// <value>
        ///     The products.
        /// </value>
        public ICollection<OfficeProduct> Products { get; set; }

        #endregion
    }
}