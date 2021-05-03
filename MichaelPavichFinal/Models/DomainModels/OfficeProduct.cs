using System.ComponentModel.DataAnnotations;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the OfficeProduct class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class OfficeProduct
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
        [Required(ErrorMessage = "Please specify a name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        /// <value>
        ///     The price.
        /// </value>
        [Required(ErrorMessage = "Please specify a price")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        /// <summary>
        ///     Gets or sets the product type identifier.
        /// </summary>
        /// <value>
        ///     The product type identifier.
        /// </value>
        [Required(ErrorMessage = "Please specify a product type")]
        public string ProductTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public ProductType Type { get; set; }

        /// <summary>
        ///     Gets or sets the image identifier.
        /// </summary>
        /// <value>
        ///     The image identifier.
        /// </value>
        public int ImageId { get; set; }

        /// <summary>
        ///     Gets or sets the image.
        /// </summary>
        /// <value>
        ///     The image.
        /// </value>
        public Image Image { get; set; }

        #endregion
    }
}