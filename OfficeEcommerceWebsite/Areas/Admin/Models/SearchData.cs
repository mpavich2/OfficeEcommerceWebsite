using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the SearchData class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class SearchData
    {
        #region Data members

        private const string SearchKey = "search";
        private const string TypeKey = "searchtype";

        #endregion

        #region Properties

        private ITempDataDictionary TempData { get; }

        /// <summary>
        ///     Gets or sets the search term.
        /// </summary>
        /// <value>
        ///     The search term.
        /// </value>
        public string SearchTerm
        {
            get => this.TempData.Peek(SearchKey)?.ToString();
            set => this.TempData[SearchKey] = value;
        }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public string Type
        {
            get => this.TempData.Peek(TypeKey)?.ToString();
            set => this.TempData[TypeKey] = value;
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has search term.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has search term; otherwise, <c>false</c>.
        /// </value>
        public bool HasSearchTerm => !string.IsNullOrEmpty(this.SearchTerm);

        /// <summary>
        ///     Gets a value indicating whether this instance is product.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is product; otherwise, <c>false</c>.
        /// </value>
        public bool IsProduct => this.Type.EqualsNoCase("product");

        /// <summary>
        ///     Gets a value indicating whether this instance is type.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is type; otherwise, <c>false</c>.
        /// </value>
        public bool IsType => this.Type.EqualsNoCase("type");

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchData" /> class.
        /// </summary>
        /// <param name="temp">The temporary.</param>
        public SearchData(ITempDataDictionary temp)
        {
            this.TempData = temp;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Clears this instance.
        /// </summary>
        public void Clear()
        {
            this.TempData.Remove(SearchKey);
            this.TempData.Remove(TypeKey);
        }

        #endregion
    }
}