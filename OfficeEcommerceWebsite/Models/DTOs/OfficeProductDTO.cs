namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the OfficeProductDTO class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="MichaelPavichFinal.Models.GridDTO" />
    public class OfficeProductDTO : GridDTO
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the office product identifier.
        /// </summary>
        /// <value>
        ///     The office product identifier.
        /// </value>
        public int OfficeProductId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>
        ///     The price.
        /// </value>
        public double Price { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Loads the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Load(OfficeProduct product)
        {
            this.OfficeProductId = product.OfficeProductId;
            this.Name = product.Name;
            this.Price = product.Price;
        }

        #endregion
    }
}