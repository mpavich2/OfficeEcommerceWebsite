﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models.DomainModels;

namespace MichaelPavichFinal.Models
{
    public class OfficeProductListViewModel
    {
        public IEnumerable<OfficeProduct> Products { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}