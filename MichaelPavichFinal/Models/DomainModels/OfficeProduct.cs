using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Models
{
    public class OfficeProduct
    {
        public int OfficeProductId { get; set; }

        [Required(ErrorMessage = "Please specify a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please specify a price")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please specify a product type")]
        public string ProductTypeId { get; set; }

        public ProductType Type { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
