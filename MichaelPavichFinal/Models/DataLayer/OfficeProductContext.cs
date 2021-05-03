using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the OfficeProductContext class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{MichaelPavichFinal.Models.User}" />
    public class OfficeProductContext : IdentityDbContext<User>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the products.
        /// </summary>
        /// <value>
        ///     The products.
        /// </value>
        public DbSet<OfficeProduct> Products { get; set; }

        /// <summary>
        ///     Gets or sets the types.
        /// </summary>
        /// <value>
        ///     The types.
        /// </value>
        public DbSet<ProductType> Types { get; set; }

        /// <summary>
        ///     Gets or sets the images.
        /// </summary>
        /// <value>
        ///     The images.
        /// </value>
        public DbSet<Image> Images { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OfficeProductContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public OfficeProductContext(DbContextOptions<OfficeProductContext> options)
            : base(options)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Override this method to further configure the model that was discovered by convention from the entity types
        ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting
        ///     model may be cached
        ///     and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        /// </param>
        /// <remarks>
        ///     If a model is explicitly set on the options for this context (via
        ///     <see
        ///         cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />
        ///     )
        ///     then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OfficeProduct>().HasOne(op => op.Type)
                        .WithMany(t => t.Products)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new SeedOfficeProducts());
            modelBuilder.ApplyConfiguration(new SeedProductTypes());
            modelBuilder.ApplyConfiguration(new SeedImages());
        }

        /// <summary>
        ///     Creates the admin user.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            var userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var username = "admin";
            var password = "password";
            var roleName = "Admin";

            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new User {UserName = username};
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        #endregion
    }
}