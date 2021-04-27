using System.Text.Json.Serialization;
using MichaelPavichFinal.Models.DTOs;

namespace MichaelPavichFinal.Models
{
    public class CartItem
    {
        public OfficeProductDTO Product { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => this.Product.Price * this.Quantity;
    }
}
