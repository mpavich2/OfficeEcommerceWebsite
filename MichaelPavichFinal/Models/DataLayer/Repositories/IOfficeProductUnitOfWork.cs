namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the IOfficeProductUnitOfWork interface.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public interface IOfficeProductUnitOfWork
    {
        #region Properties

        /// <summary>
        ///     Gets the products.
        /// </summary>
        /// <value>
        ///     The products.
        /// </value>
        Repository<OfficeProduct> Products { get; }

        /// <summary>
        ///     Gets the types.
        /// </summary>
        /// <value>
        ///     The types.
        /// </value>
        Repository<ProductType> Types { get; }

        /// <summary>
        ///     Gets the images.
        /// </summary>
        /// <value>
        ///     The images.
        /// </value>
        Repository<Image> Images { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        void Save();

        #endregion
    }
}