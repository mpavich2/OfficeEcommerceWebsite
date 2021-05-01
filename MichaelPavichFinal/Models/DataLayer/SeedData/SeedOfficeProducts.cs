using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MichaelPavichFinal.Models
{
    public class SeedOfficeProducts : IEntityTypeConfiguration<OfficeProduct>
    {
        public void Configure(EntityTypeBuilder<OfficeProduct> entity)
        {
            entity.HasData(
                new OfficeProduct { OfficeProductId = 1, Name = "WorkPro® Quantum 9000 Mesh Series Ergonomic Mid-Back Manager's Chair", Price = 349.99, ProductTypeId = "chair" },
                new OfficeProduct { OfficeProductId = 2, Name = "Brenton Studio® Ruzzi Mid-Back Manager's Chair", Price = 89.99, ProductTypeId = "chair" }
            );
        }
    }
}
