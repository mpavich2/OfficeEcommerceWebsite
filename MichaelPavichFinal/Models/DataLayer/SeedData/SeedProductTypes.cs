using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MichaelPavichFinal.Models
{
    public class SeedProductTypes : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> entity)
        {
            entity.HasData(
                new ProductType { ProductTypeId = "chair", Name = "Office Chairs" },
                new ProductType { ProductTypeId = "desk", Name = "Office Desks" }
            );
        }
    }
}
