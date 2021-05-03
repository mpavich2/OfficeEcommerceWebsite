namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the CartItemDTO class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class CartItemDTO
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
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public int Quantity { get; set; }

        #endregion
    }
}