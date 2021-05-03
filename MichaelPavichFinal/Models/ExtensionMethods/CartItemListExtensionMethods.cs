using System.Collections.Generic;
using System.Linq;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the CartItemListExtensions class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public static class CartItemListExtensions
    {
        #region Methods

        /// <summary>
        ///     Converts to dto.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static List<CartItemDTO> ToDTO(this List<CartItem> list)
        {
            return list.Select(ci => new CartItemDTO {
                OfficeProductId = ci.Product.OfficeProductId,
                Quantity = ci.Quantity
            }).ToList();
        }

        #endregion
    }
}