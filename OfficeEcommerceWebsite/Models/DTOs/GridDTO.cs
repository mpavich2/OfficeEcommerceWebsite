namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the GridDTO class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class GridDTO
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the page number.
        /// </summary>
        /// <value>
        ///     The page number.
        /// </value>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        ///     Gets or sets the size of the page.
        /// </summary>
        /// <value>
        ///     The size of the page.
        /// </value>
        public int PageSize { get; set; } = 4;

        /// <summary>
        ///     Gets or sets the sort field.
        /// </summary>
        /// <value>
        ///     The sort field.
        /// </value>
        public string SortField { get; set; }

        /// <summary>
        ///     Gets or sets the sort direction.
        /// </summary>
        /// <value>
        ///     The sort direction.
        /// </value>
        public string SortDirection { get; set; } = "asc";

        #endregion
    }
}