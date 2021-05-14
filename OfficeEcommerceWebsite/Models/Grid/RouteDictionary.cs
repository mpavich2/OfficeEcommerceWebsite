using System.Collections.Generic;
using System.Linq;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the FilterPrefix class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class FilterPrefix
    {
        #region Data members

        /// <summary>
        ///     The product type
        /// </summary>
        public const string ProductType = "type-";

        #endregion
    }

    /// <summary>
    ///     Defines the RouteDictionary class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, System.String}" />
    public class RouteDictionary : Dictionary<string, string>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the page number.
        /// </summary>
        /// <value>
        ///     The page number.
        /// </value>
        public int PageNumber
        {
            get => this.get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        /// <summary>
        ///     Gets or sets the size of the page.
        /// </summary>
        /// <value>
        ///     The size of the page.
        /// </value>
        public int PageSize
        {
            get => this.get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        /// <summary>
        ///     Gets or sets the sort field.
        /// </summary>
        /// <value>
        ///     The sort field.
        /// </value>
        public string SortField
        {
            get => this.get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        /// <summary>
        ///     Gets or sets the sort direction.
        /// </summary>
        /// <value>
        ///     The sort direction.
        /// </value>
        public string SortDirection
        {
            get => this.get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        /// <summary>
        ///     Gets or sets the product type filter.
        /// </summary>
        /// <value>
        ///     The product type filter.
        /// </value>
        public string ProductTypeFilter
        {
            get => this.get(nameof(OfficeProductGridDTO.ProductType))?.Replace(FilterPrefix.ProductType, "");
            set => this[nameof(OfficeProductGridDTO.ProductType)] = value;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Sets the sort and direction.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="current">The current.</param>
        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) &&
                current.SortDirection == "asc")
            {
                this[nameof(GridDTO.SortDirection)] = "desc";
            }
            else
            {
                this[nameof(GridDTO.SortDirection)] = "asc";
            }
        }

        /// <summary>
        ///     Clears the filters.
        /// </summary>
        public void ClearFilters()
        {
            this.ProductTypeFilter = OfficeProductGridDTO.DefaultFilter;
        }

        private string get(string key)
        {
            return Keys.Contains(key) ? this[key] : null;
        }

        /// <summary>
        ///     Clones this instance.
        /// </summary>
        /// <returns></returns>
        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }

            return clone;
        }

        #endregion
    }
}