using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models.Grid;

namespace MichaelPavichFinal.Models
{
    public class OfficeProductQueryOptions : QueryOptions<OfficeProduct>
    {
        public void SortFilter(OfficeProductsGridBuilder builder)
        {
            if (builder.IsFilterByProductType)
            {
                Where = b => b.ProductTypeId == builder.CurrentRoute.ProductTypeFilter;
            }

            if (builder.IsSortByProductType)
            {
                OrderBy = b => b.Type.Name;
            }
            else if (builder.IsSortByPrice)
            {
                OrderBy = b => b.Price;
            }
            else
            {
                OrderBy = b => b.Name;
            }
        }
    }
}
