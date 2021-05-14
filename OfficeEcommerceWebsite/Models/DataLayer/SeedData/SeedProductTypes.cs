using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfficeEcommerceWebsite.Models
{
    /// <summary>
    ///     Defines the SeedProductTypes class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{MichaelPavichFinal.Models.ProductType}" />
    public class SeedProductTypes : IEntityTypeConfiguration<ProductType>
    {
        #region Methods

        /// <summary>
        ///     Configures the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Configure(EntityTypeBuilder<ProductType> entity)
        {
            entity.HasData(
                new ProductType {ProductTypeId = "chair", Name = "Office Chairs"},
                new ProductType {ProductTypeId = "desk", Name = "Office Desks"}
            );
        }

        #endregion
    }
}