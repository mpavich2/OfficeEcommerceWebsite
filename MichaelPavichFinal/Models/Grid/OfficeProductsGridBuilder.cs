using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MichaelPavichFinal.Models.Grid
{
    public class OfficeProductsGridBuilder : GridBuilder
    {
        public OfficeProductsGridBuilder(ISession sess) : base(sess) { }

        public OfficeProductsGridBuilder(ISession sess, OfficeProductGridDTO values,
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.ProductType.IndexOf(FilterPrefix.ProductType) == -1;
            routes.ProductTypeFilter = (isInitial) ? FilterPrefix.ProductType + values.ProductType : values.ProductType;
        }

        public void LoadFilterSegments(string[] filter)
        {
            routes.ProductTypeFilter = FilterPrefix.ProductType + filter[0];
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = OfficeProductGridDTO.DefaultFilter;
        public bool IsFilterByProductType => routes.ProductTypeFilter != def;

        public bool IsSortByProductType =>
            routes.SortField.EqualsNoCase(nameof(ProductType));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(OfficeProduct.Price));
    }
}
