using Microsoft.AspNetCore.Http;

namespace MichaelPavichFinal.Models.Grid
{
    /// <summary>
    ///     Defines the OfficeProductsGridBuilder class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="MichaelPavichFinal.Models.GridBuilder" />
    public class OfficeProductsGridBuilder : GridBuilder
    {
        #region Data members

        private const string Def = OfficeProductGridDTO.DefaultFilter;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets a value indicating whether this instance is filter by product type.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is filter by product type; otherwise, <c>false</c>.
        /// </value>
        public bool IsFilterByProductType => Routes.ProductTypeFilter != Def;

        /// <summary>
        ///     Gets a value indicating whether this instance is sort by product type.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is sort by product type; otherwise, <c>false</c>.
        /// </value>
        public bool IsSortByProductType =>
            Routes.SortField.EqualsNoCase(nameof(ProductType));

        /// <summary>
        ///     Gets a value indicating whether this instance is sort by price.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is sort by price; otherwise, <c>false</c>.
        /// </value>
        public bool IsSortByPrice =>
            Routes.SortField.EqualsNoCase(nameof(OfficeProduct.Price));

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OfficeProductsGridBuilder" /> class.
        /// </summary>
        /// <param name="sess">The sess.</param>
        public OfficeProductsGridBuilder(ISession sess) : base(sess)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OfficeProductsGridBuilder" /> class.
        /// </summary>
        /// <param name="sess">The sess.</param>
        /// <param name="values">The values.</param>
        /// <param name="defaultSortField">The default sort field.</param>
        public OfficeProductsGridBuilder(ISession sess, OfficeProductGridDTO values,
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            var isInitial = values.ProductType.IndexOf(FilterPrefix.ProductType) == -1;
            Routes.ProductTypeFilter = isInitial ? FilterPrefix.ProductType + values.ProductType : values.ProductType;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Loads the filter segments.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public void LoadFilterSegments(string[] filter)
        {
            Routes.ProductTypeFilter = FilterPrefix.ProductType + filter[0];
        }

        /// <summary>
        ///     Clears the filter segments.
        /// </summary>
        public void ClearFilterSegments()
        {
            Routes.ClearFilters();
        }

        #endregion
    }
}