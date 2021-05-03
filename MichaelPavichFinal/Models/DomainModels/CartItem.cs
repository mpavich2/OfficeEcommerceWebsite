using System.Text.Json.Serialization;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the CartItem clas.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class CartItem
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the product.
        /// </summary>
        /// <value>
        ///     The product.
        /// </value>
        public OfficeProductDTO Product { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        ///     Gets the subtotal.
        /// </summary>
        /// <value>
        ///     The subtotal.
        /// </value>
        [JsonIgnore]
        public double Subtotal => this.Product.Price * this.Quantity;

        #endregion
    }
}