using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelPavichFinal.Models
{
    public class OfficeProductContext : IdentityDbContext<User>
    {
        public OfficeProductContext(DbContextOptions<OfficeProductContext> options)
            : base(options)
        { }

        public DbSet<OfficeProduct> Products { get; set; }

        public DbSet<ProductType> Types { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OfficeProduct>().HasOne(op => op.Type)
                        .WithMany(t => t.Products)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new SeedOfficeProducts());
            modelBuilder.ApplyConfiguration(new SeedProductTypes());
        }

        /// <summary>
        /// Creates the admin user.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = "admin";
            string password = "password";
            string roleName = "Admin";

            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
