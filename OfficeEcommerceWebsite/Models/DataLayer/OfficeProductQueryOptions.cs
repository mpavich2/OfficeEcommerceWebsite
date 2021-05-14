using OfficeEcommerceWebsite.Models;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the OfficeProductQueryOptions class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="MichaelPavichFinal.Models.QueryOptions{MichaelPavichFinal.Models.OfficeProduct}" />
    public class OfficeProductQueryOptions : QueryOptions<OfficeProduct>
    {
        #region Methods

        public void SortFilter(OfficeProductsGridBuilder builder)
        {
            if (builder.IsFilterByProductType)
            {
                Where = b => b.ProductTypeId == builder.CurrentRoute.ProductTypeFilter;
            }

            if (builder.IsSortByProductType)
            {
                OrderBy = b => b.Type.Name;
            }
            else if (builder.IsSortByPrice)
            {
                OrderBy = b => b.Price;
            }
            else
            {
                OrderBy = b => b.Name;
            }
        }

        #endregion
    }
}