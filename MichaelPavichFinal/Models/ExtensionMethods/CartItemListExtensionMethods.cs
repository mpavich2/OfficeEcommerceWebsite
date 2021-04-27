using System.Linq;
using System.Collections.Generic;
using MichaelPavichFinal.Models;

namespace MichaelPavichFinal.Models
{
    public static class CartItemListExtensions
    {
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO {
                OfficeProductId = ci.Product.OfficeProductId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
