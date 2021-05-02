using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Models
{
    public class OfficeProductViewModel
    {
        public OfficeProduct Product { get; set; }
        public IEnumerable<ProductType> Types { get; set; }
    }
}
