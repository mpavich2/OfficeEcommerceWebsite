using Newtonsoft.Json;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the OfficeProductGridDTO class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="MichaelPavichFinal.Models.GridDTO" />
    public class OfficeProductGridDTO : GridDTO
    {
        #region Data members

        /// <summary>
        ///     The default filter
        /// </summary>
        [JsonIgnore] public const string DefaultFilter = "all";

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the type of the product.
        /// </summary>
        /// <value>
        ///     The type of the product.
        /// </value>
        public string ProductType { get; set; } = DefaultFilter;

        #endregion
    }
}