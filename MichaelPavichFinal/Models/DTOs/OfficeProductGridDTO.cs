using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MichaelPavichFinal.Models
{
    public class OfficeProductGridDTO : GridDTO
    {
        [JsonIgnore] 
        public const string DefaultFilter = "all";

        public string ProductType { get; set; } = DefaultFilter;
    }
}
