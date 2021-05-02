using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Models
{
    public class ProductType
    {
        public string ProductTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<OfficeProduct> Products { get; set; }
    }
}
