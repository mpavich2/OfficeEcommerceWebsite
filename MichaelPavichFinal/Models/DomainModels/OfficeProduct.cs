using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models.DomainModels;

namespace MichaelPavichFinal.Models
{
    public class OfficeProduct
    {
        public int OfficeProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ProductTypeId { get; set; }

        public ProductType Type { get; set; }
    }
}
