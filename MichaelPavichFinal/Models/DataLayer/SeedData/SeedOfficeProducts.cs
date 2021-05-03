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
                new OfficeProduct { OfficeProductId = 1, Name = "WorkPro® Quantum 9000 Mesh Series Ergonomic Mid-Back Manager's Chair", Price = 349.99, ProductTypeId = "chair", ImageId = 1 },
                new OfficeProduct { OfficeProductId = 2, Name = "Brenton Studio® Ruzzi Mid-Back Manager's Chair", Price = 89.99, ProductTypeId = "chair", ImageId = 2 },
                new OfficeProduct { OfficeProductId = 3, Name = "Realspace® Magellan 59 W L - Shaped Desk", Price = 199.99, ProductTypeId = "desk", ImageId = 6 },
                new OfficeProduct { OfficeProductId = 4, Name = "Realspace® Calusa Mesh Mid-Back Manager's Chair", Price = 99.99, ProductTypeId = "chair", ImageId = 5 },
                new OfficeProduct { OfficeProductId = 5, Name = "Realspace Magellan 59 W Managers Desk", Price = 189.99, ProductTypeId = "desk", ImageId = 4 },
                new OfficeProduct { OfficeProductId = 6, Name = "Sauder® Edge Water 66 W Executive Desk", Price = 414.99, ProductTypeId = "desk", ImageId = 3 }
            );
        }
    }
}
