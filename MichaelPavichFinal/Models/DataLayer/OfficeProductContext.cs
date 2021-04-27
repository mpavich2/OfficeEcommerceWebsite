using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichaelPavichFinal.Models.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MichaelPavichFinal.Models.DataLayer
{
    public class OfficeProductContext : IdentityDbContext<User>
    {
        public OfficeProductContext(DbContextOptions<OfficeProductContext> options)
            : base(options)
        { }

        public DbSet<OfficeProduct> Products { get; set; }

        public DbSet<ProductType> Types { get; set; }
    }
}
