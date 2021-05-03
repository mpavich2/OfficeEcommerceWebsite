using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the SearchViewModel class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class SearchViewModel
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
        ///     Gets or sets the search term.
        /// </summary>
        /// <value>
        ///     The search term.
        /// </value>
        [Required(ErrorMessage = "Please enter a search term.")]
        public string SearchTerm { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the header.
        /// </summary>
        /// <value>
        ///     The header.
        /// </value>
        public string Header { get; set; }

        #endregion
    }
}